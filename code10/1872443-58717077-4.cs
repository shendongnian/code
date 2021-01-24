    public sealed class SynchronizedJoinBlock<T1, T2> : IReceivableSourceBlock<(T1, T2)>
    {
        private readonly Func<T1, T2, int> _comparison;
        private readonly Queue<T1> _queue1 = new Queue<T1>();
        private readonly Queue<T2> _queue2 = new Queue<T2>();
        private readonly ActionBlock<T1> _input1;
        private readonly ActionBlock<T2> _input2;
        private readonly BufferBlock<(T1, T2)> _output;
        private readonly object _locker = new object();
        public SynchronizedJoinBlock(Func<T1, T2, int> comparison,
            CancellationToken cancellationToken = default)
        {
            _comparison = comparison ?? throw new ArgumentNullException(nameof(comparison));
            // Create the three internal blocks
            var options = new ExecutionDataflowBlockOptions()
            {
                CancellationToken = cancellationToken
            };
            _input1 = new ActionBlock<T1>(Add1, options);
            _input2 = new ActionBlock<T2>(Add2, options);
            _output = new BufferBlock<(T1, T2)>(options);
            // Link the input blocks with the output block
            var inputTasks = new Task[] { _input1.Completion, _input2.Completion };
            Task.WhenAny(inputTasks).Unwrap().ContinueWith(t =>
            {
                // If ANY input block fails, then the whole block has failed
                ((IDataflowBlock)_output).Fault(t.Exception.InnerException);
                if (!_input1.Completion.IsCompleted) _input1.Complete();
                if (!_input2.Completion.IsCompleted) _input2.Complete();
                ClearQueues();
            }, default, TaskContinuationOptions.OnlyOnFaulted |
                TaskContinuationOptions.RunContinuationsAsynchronously,
                TaskScheduler.Default);
            Task.WhenAll(inputTasks).ContinueWith(t =>
            {
                // If ALL input blocks succeeded, then the whole block has succeeded
                try
                {
                    if (!t.IsCanceled) PostRemaining(); // Post what's left
                }
                catch (Exception ex)
                {
                    ((IDataflowBlock)_output).Fault(ex);
                }
                _output.Complete();
                ClearQueues();
            }, default, TaskContinuationOptions.NotOnFaulted |
                TaskContinuationOptions.RunContinuationsAsynchronously,
                TaskScheduler.Default);
        }
        public ITargetBlock<T1> Target1 => _input1;
        public ITargetBlock<T2> Target2 => _input2;
        public Task Completion => _output.Completion;
        private void Add1(T1 value1)
        {
            lock (_locker)
            {
                _queue1.Enqueue(value1);
                FindAndPostMatched_Unsafe();
            }
        }
        private void Add2(T2 value2)
        {
            lock (_locker)
            {
                _queue2.Enqueue(value2);
                FindAndPostMatched_Unsafe();
            }
        }
        private void FindAndPostMatched_Unsafe()
        {
            while (_queue1.Count > 0 && _queue2.Count > 0)
            {
                var result = _comparison(_queue1.Peek(), _queue2.Peek());
                if (result < 0)
                {
                    _output.Post((_queue1.Dequeue(), default));
                }
                else if (result > 0)
                {
                    _output.Post((default, _queue2.Dequeue()));
                }
                else // result == 0
                {
                    _output.Post((_queue1.Dequeue(), _queue2.Dequeue()));
                }
            }
        }
        private void PostRemaining()
        {
            lock (_locker)
            {
                while (_queue1.Count > 0)
                {
                    _output.Post((_queue1.Dequeue(), default));
                }
                while (_queue2.Count > 0)
                {
                    _output.Post((default, _queue2.Dequeue()));
                }
            }
        }
        private void ClearQueues()
        {
            lock (_locker)
            {
                _queue1.Clear();
                _queue2.Clear();
            }
        }
        public void Complete() => _output.Complete();
        public void Fault(Exception exception)
            => ((IDataflowBlock)_output).Fault(exception);
        public IDisposable LinkTo(ITargetBlock<(T1, T2)> target,
            DataflowLinkOptions linkOptions)
            => _output.LinkTo(target, linkOptions);
        public bool TryReceive(Predicate<(T1, T2)> filter, out (T1, T2) item)
            => _output.TryReceive(filter, out item);
        public bool TryReceiveAll(out IList<(T1, T2)> items)
            => _output.TryReceiveAll(out items);
        (T1, T2) ISourceBlock<(T1, T2)>.ConsumeMessage(
            DataflowMessageHeader messageHeader, ITargetBlock<(T1, T2)> target,
            out bool messageConsumed)
            => ((ISourceBlock<(T1, T2)>)_output).ConsumeMessage(
                messageHeader, target, out messageConsumed);
        void ISourceBlock<(T1, T2)>.ReleaseReservation(
            DataflowMessageHeader messageHeader, ITargetBlock<(T1, T2)> target)
            => ((ISourceBlock<(T1, T2)>)_output).ReleaseReservation(
                messageHeader, target);
        bool ISourceBlock<(T1, T2)>.ReserveMessage(
            DataflowMessageHeader messageHeader, ITargetBlock<(T1, T2)> target)
            => ((ISourceBlock<(T1, T2)>)_output).ReserveMessage(
                messageHeader, target);
    }
