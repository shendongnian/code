    public class JoinDependencyBlock<T1, T2> : ISourceBlock<(T1, T2)>
    {
        private readonly Func<T1, T2, bool> _matchPredicate;
        private readonly List<T1> _list1 = new List<T1>();
        private readonly List<T2> _list2 = new List<T2>();
        private readonly ActionBlock<T1> _input1;
        private readonly ActionBlock<T2> _input2;
        private readonly BufferBlock<(T1, T2)> _output;
        private readonly object _locker = new object();
        public JoinDependencyBlock(Func<T1, T2, bool> matchPredicate,
            CancellationToken cancellationToken)
        {
            _matchPredicate = matchPredicate
                ?? throw new ArgumentNullException(nameof(matchPredicate));
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
                ClearLists();
            }, default, TaskContinuationOptions.OnlyOnFaulted |
                TaskContinuationOptions.RunContinuationsAsynchronously,
                TaskScheduler.Default);
            Task.WhenAll(inputTasks).ContinueWith(t =>
            {
                // If ALL input blocks succeeded, then the whole block has succeeded
                _output.Complete();
                ClearLists();
            }, default, TaskContinuationOptions.NotOnFaulted |
                TaskContinuationOptions.RunContinuationsAsynchronously,
                TaskScheduler.Default);
        }
        public JoinDependencyBlock(Func<T1, T2, bool> matchPredicate)
            : this(matchPredicate, CancellationToken.None) { }
        public ITargetBlock<T1> Target1 => _input1;
        public ITargetBlock<T2> Target2 => _input2;
        public Task Completion => _output.Completion;
        private void Add1(T1 value1)
        {
            T2 value2;
            lock (_locker)
            {
                var index = _list2.FindIndex(v => _matchPredicate(value1, v));
                if (index < 0)
                {
                    // Match not found
                    _list1.Add(value1);
                    return;
                }
                value2 = _list2[index];
                _list2.RemoveAt(index);
            }
            _output.Post((value1, value2));
        }
        private void Add2(T2 value2)
        {
            T1 value1;
            lock (_locker)
            {
                var index = _list1.FindIndex(v => _matchPredicate(v, value2));
                if (index < 0)
                {
                    // Match not found
                    _list2.Add(value2);
                    return;
                }
                value1 = _list1[index];
                _list1.RemoveAt(index);
            }
            _output.Post((value1, value2));
        }
        private void ClearLists()
        {
            lock (_locker)
            {
                _list1.Clear();
                _list2.Clear();
            }
        }
        public void Complete() => _output.Complete();
        public void Fault(Exception exception)
            => ((IDataflowBlock)_output).Fault(exception);
        public IDisposable LinkTo(ITargetBlock<(T1, T2)> target,
            DataflowLinkOptions linkOptions)
            => _output.LinkTo(target, linkOptions);
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
