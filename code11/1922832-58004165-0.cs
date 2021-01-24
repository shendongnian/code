    public class JoinDependencyBlock<T1, T2> : ISourceBlock<(T1, T2)>
    {
        private readonly Func<T1, T2, bool> _matchPredicate;
        private readonly List<T1> _list1 = new List<T1>();
        private readonly List<T2> _list2 = new List<T2>();
        private readonly TargetBlock<T1> _target1;
        private readonly TargetBlock<T2> _target2;
        private readonly BufferBlock<(T1, T2)> _outputBlock;
        private readonly object _locker = new object();
        public JoinDependencyBlock(Func<T1, T2, bool> matchPredicate)
        {
            _matchPredicate = matchPredicate
                ?? throw new ArgumentNullException(nameof(matchPredicate));
            _target1 = new TargetBlock<T1>(Add1);
            _target2 = new TargetBlock<T2>(Add2);
            _outputBlock = new BufferBlock<(T1, T2)>(); // Unbounded
            var completionOfBothTargets = Task.WhenAll(
                this.Target1.Completion, this.Target2.Completion);
            completionOfBothTargets.ContinueWith(t =>
            {
                if (t.IsFaulted)
                {
                    ((IDataflowBlock)_outputBlock).Fault(t.Exception.InnerException);
                }
                else
                {
                    FindRemainingMatchesAndDiscardTheUnmatched();
                    _outputBlock.Complete();
                }
            }, default, TaskContinuationOptions.RunContinuationsAsynchronously,
                TaskScheduler.Default);
        }
        public ITargetBlock<T1> Target1 => _target1;
        public ITargetBlock<T2> Target2 => _target2;
        public Task Completion => _outputBlock.Completion;
        private void Add1(T1 value)
        {
            lock (_locker) _list1.Add(value);
            var fireAndForget = FindMatchAsync(this.Target1);
        }
        private void Add2(T2 value)
        {
            lock (_locker) _list2.Add(value);
            var fireAndForget = FindMatchAsync(this.Target2);
        }
        private Task FindMatchAsync(IDataflowBlock inputBlock)
        {
            return Task.Run(() =>
            {
                try
                {
                    FindMatch();
                }
                catch (Exception ex)
                {
                    inputBlock.Fault(ex);
                }
            });
        }
        private bool FindMatch()
        {
            T1 value1;
            T2 value2;
            lock (_locker)
            {
                for (int i = 0; i < _list1.Count; i++)
                {
                    for (int j = 0; j < _list2.Count; j++)
                    {
                        if (_matchPredicate(_list1[i], _list2[j]))
                        {
                            value1 = _list1[i];
                            value2 = _list2[j];
                            _list1.RemoveAt(i);
                            _list2.RemoveAt(j);
                            goto matched;
                        }
                    }
                }
                return false;
            }
        matched:
            _outputBlock.Post((value1, value2));
            return true;
        }
        private void FindRemainingMatchesAndDiscardTheUnmatched()
        {
            try
            {
                while (FindMatch()) { }
                lock (_locker)
                {
                    _list1.Clear();
                    _list2.Clear();
                }
            }
            catch (Exception ex)
            {
                // At this point both TargetBlocks are completed
                ((IDataflowBlock)_outputBlock).Fault(ex);
            }
        }
        public void Complete()
        {
            this.Target1.Complete();
            this.Target2.Complete();
            _outputBlock.Complete();
        }
        void IDataflowBlock.Fault(Exception exception)
        {
            this.Target1.Fault(exception);
            this.Target2.Fault(exception);
            ((IDataflowBlock)_outputBlock).Fault(exception);
        }
        public IDisposable LinkTo(ITargetBlock<(T1, T2)> target,
            DataflowLinkOptions linkOptions)
        {
            return _outputBlock.LinkTo(target, linkOptions);
        }
        (T1, T2) ISourceBlock<(T1, T2)>.ConsumeMessage(
            DataflowMessageHeader messageHeader, ITargetBlock<(T1, T2)> target,
            out bool messageConsumed)
            => throw new NotSupportedException("ConsumeMessage");
        void ISourceBlock<(T1, T2)>.ReleaseReservation(
            DataflowMessageHeader messageHeader, ITargetBlock<(T1, T2)> target)
            => throw new NotSupportedException("ReleaseReservation");
        bool ISourceBlock<(T1, T2)>.ReserveMessage(
            DataflowMessageHeader messageHeader, ITargetBlock<(T1, T2)> target)
            => throw new NotSupportedException("ReserveMessage");
        private class TargetBlock<T> : ITargetBlock<T>
        {
            private readonly Action<T> _callback;
            private readonly TaskCompletionSource<bool> _completion
                = new TaskCompletionSource<bool>(
                TaskCreationOptions.RunContinuationsAsynchronously);
            public TargetBlock(Action<T> callback)
            {
                _callback = callback;
            }
            public Task Completion => _completion.Task;
            public void Complete() => _completion.TrySetResult(true);
            public void Fault(Exception exception)
                => _completion.TrySetException(exception);
            public DataflowMessageStatus OfferMessage(
                DataflowMessageHeader messageHeader, T messageValue,
                ISourceBlock<T> source, bool consumeToAccept)
            {
                if (_completion.Task.IsCompleted)
                    return DataflowMessageStatus.DecliningPermanently;
                if (consumeToAccept) throw new NotSupportedException("consumeToAccept");
                _callback(messageValue);
                return DataflowMessageStatus.Accepted;
            }
        }
    }
