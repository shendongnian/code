csharp
    public sealed class SynchronizedJoinBlock<T1, T2>
        : IReceivableSourceBlock<Tuple<T1, T2>>
    {
        private readonly Func<T1, T2, int> _compareFunction;
        private readonly Queue<T1> _target1Messages;
        private readonly Queue<T2> _target2Messages;
        private readonly TransformManyBlock<T1, Tuple<T1, T2>> _target1;
        private readonly TransformManyBlock<T2, Tuple<T1, T2>> _target2;
        private readonly BatchedJoinBlock<Tuple<T1, T2>, Tuple<T1, T2>> _batchedJoinBlock;
        private readonly TransformManyBlock<Tuple<IList<Tuple<T1, T2>>, IList<Tuple<T1, T2>>>, Tuple<T1, T2>> _transformManyBlock;
        public ITargetBlock<T1> Target1 => _target1;
        public ITargetBlock<T2> Target2 => _target2;
        public Task Completion => _transformManyBlock.Completion;
        public SynchronizedJoinBlock(Func<T1, T2, int> compareFunction)
        {
            _compareFunction = compareFunction
                ?? throw new ArgumentNullException(nameof(compareFunction));
            _batchedJoinBlock = new BatchedJoinBlock<Tuple<T1, T2>, Tuple<T1, T2>>(1);
            _target1Messages = new Queue<T1>();
            _target2Messages = new Queue<T2>();
            var syncObject = new object();
            Func<ICollection<Tuple<T1, T2>>> getMessagesFunction = () =>
            {
                lock (syncObject)
                {
                    if (_target1Messages.Count > 0 && _target2Messages.Count > 0)
                    {
                        return GetMessagesRecursive(_target1Messages.Peek(), _target2Messages.Peek()).ToArray();
                    }
                    else
                    {
                        return new Tuple<T1, T2>[0];
                    }
                }
            };
            _target1 = new TransformManyBlock<T1, Tuple<T1, T2>>((element) =>
            {
                _target1Messages.Enqueue(element);
                return getMessagesFunction();
            });
            _target1.LinkTo(_batchedJoinBlock.Target1, new DataflowLinkOptions() { PropagateCompletion = true });
            _target2 = new TransformManyBlock<T2, Tuple<T1, T2>>((element) =>
            {
                _target2Messages.Enqueue(element);
                return getMessagesFunction();
            });
            _target2.LinkTo(_batchedJoinBlock.Target2, new DataflowLinkOptions() { PropagateCompletion = true });
            _transformManyBlock = new TransformManyBlock<Tuple<IList<Tuple<T1, T2>>, IList<Tuple<T1, T2>>>, Tuple<T1, T2>>(
                element => element.Item1.Concat(element.Item2)
            );
            _batchedJoinBlock.LinkTo(_transformManyBlock, new DataflowLinkOptions() { PropagateCompletion = true });
        }
        private IEnumerable<Tuple<T1, T2>> GetMessagesRecursive(T1 value1, T2 value2)
        {
            int result = _compareFunction(value1, value2);
            if (result == 0)
            {
                yield return Tuple.Create(_target1Messages.Dequeue(), _target2Messages.Dequeue());
            }
            else if (result < 0)
            {
                yield return Tuple.Create(_target1Messages.Dequeue(), default(T2));
                if (_target1Messages.Count > 0)
                {
                    foreach (var item in GetMessagesRecursive(_target1Messages.Peek(), value2))
                    {
                        yield return item;
                    }
                }
            }
            else
            {
                yield return Tuple.Create(default(T1), _target2Messages.Dequeue());
                if (_target2Messages.Count > 0)
                {
                    foreach (var item in GetMessagesRecursive(value1, _target2Messages.Peek()))
                    {
                        yield return item;
                    }
                }
            }
        }
        public void Complete()
        {
            _target1.Complete();
            _target2.Complete();
        }
        Tuple<T1, T2> ISourceBlock<Tuple<T1, T2>>.ConsumeMessage(
            DataflowMessageHeader messageHeader,
            ITargetBlock<Tuple<T1, T2>> target, out bool messageConsumed)
        {
            return ((ISourceBlock<Tuple<T1, T2>>)_transformManyBlock)
                .ConsumeMessage(messageHeader, target, out messageConsumed);
        }
        void IDataflowBlock.Fault(Exception exception)
        {
            ((IDataflowBlock)_transformManyBlock).Fault(exception);
        }
        public IDisposable LinkTo(ITargetBlock<Tuple<T1, T2>> target,
            DataflowLinkOptions linkOptions)
        {
            return _transformManyBlock.LinkTo(target, linkOptions);
        }
        void ISourceBlock<Tuple<T1, T2>>.ReleaseReservation(
            DataflowMessageHeader messageHeader, ITargetBlock<Tuple<T1, T2>> target)
        {
            ((ISourceBlock<Tuple<T1, T2>>)_transformManyBlock)
                .ReleaseReservation(messageHeader, target);
        }
        bool ISourceBlock<Tuple<T1, T2>>.ReserveMessage(
            DataflowMessageHeader messageHeader, ITargetBlock<Tuple<T1, T2>> target)
        {
            return ((ISourceBlock<Tuple<T1, T2>>)_transformManyBlock)
                .ReserveMessage(messageHeader, target);
        }
        public bool TryReceive(Predicate<Tuple<T1, T2>> filter, out Tuple<T1, T2> item)
        {
            return _transformManyBlock.TryReceive(filter, out item);
        }
        public bool TryReceiveAll(out IList<Tuple<T1, T2>> items)
        {
            return _transformManyBlock.TryReceiveAll(out items);
        }
    }
