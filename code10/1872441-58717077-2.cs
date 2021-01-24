    public sealed class SynchronizedJoinBlock<T1, T2> : IReceivableSourceBlock<(T1, T2)>
    {
        private readonly Func<T1, T2, int> _comparison;
        private readonly List<T1> _list1 = new List<T1>();
        private readonly List<T2> _list2 = new List<T2>();
        private readonly ActionBlock<T1> _input1;
        private readonly ActionBlock<T2> _input2;
        private readonly BufferBlock<(T1, T2)> _output;
        private readonly object _locker = new object();
        public SynchronizedJoinBlock(Func<T1, T2, int> comparison,
            CancellationToken cancellationToken)
        {
            _comparison = comparison
                ?? throw new ArgumentNullException(nameof(comparison));
            // Create the three internal blocks
            var options = new ExecutionDataflowBlockOptions()
            {
                CancellationToken = cancellationToken
            };
            _input1 = new ActionBlock<T1>(v => AddAndPost(1, v, default), options);
            _input2 = new ActionBlock<T2>(v => AddAndPost(2, default, v), options);
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
                if (!t.IsCanceled) AddAndPost(0, default, default); // Post what's left
                _output.Complete();
                ClearLists();
            }, default, TaskContinuationOptions.NotOnFaulted |
                TaskContinuationOptions.RunContinuationsAsynchronously,
                TaskScheduler.Default);
        }
        public SynchronizedJoinBlock(Func<T1, T2, int> comparison)
            : this(comparison, CancellationToken.None) { }
        public ITargetBlock<T1> Target1 => _input1;
        public ITargetBlock<T2> Target2 => _input2;
        public Task Completion => _output.Completion;
        private void AddAndPost(int typeId, T1 value1, T2 value2)
        {
            List<(T1, T2)> pairsToPost;
            lock (_locker)
            {
                switch (typeId)
                {
                    case 1: _list1.Add(value1); break;
                    case 2: _list2.Add(value2); break;
                }
                if (typeId > 0 && (_list1.Count == 0 || _list2.Count == 0)) return;
                pairsToPost = new List<(T1, T2)>(); // Allocation maybe avoidable
                int index1 = 0, index2 = 0;
                while (index1 < _list1.Count && index2 < _list2.Count)
                {
                    var result = _comparison(_list1[index1], _list2[index2]);
                    if (result < 0)
                    {
                        pairsToPost.Add((_list1[index1], default));
                        index1++;
                    }
                    else if (result > 0)
                    {
                        pairsToPost.Add((default, _list2[index2]));
                        index2++;
                    }
                    else // result == 0
                    {
                        pairsToPost.Add((_list1[index1], _list2[index2]));
                        index1++;
                        index2++;
                    }
                }
                if (typeId == 0) // Post what's left
                {
                    for (; index1 < _list1.Count; index1++)
                    {
                        pairsToPost.Add((_list1[index1], default));
                    }
                    for (; index2 < _list2.Count; index2++)
                    {
                        pairsToPost.Add((default, _list2[index2]));
                    }
                }
                _list1.RemoveRange(0, index1);
                _list2.RemoveRange(0, index2);
            }
            foreach (var pair in pairsToPost)
            {
                _output.Post(pair);
            }
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
