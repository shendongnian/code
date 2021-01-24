     public sealed class SynchronizedJoinBlock<T1, T2>
        : IReceivableSourceBlock<Tuple<T1, T2>>
    {
        private readonly Func<T1, T2, int> _compareFunction;
        private readonly JoinBlock<T1, T2> _joinBlock;
        private readonly Action<Tuple<T1, T2>> _addMessageToSource;
        private readonly Queue<T1> _target1Messages;
        private readonly Queue<T2> _target2Messages;
        public ITargetBlock<T1> Target1 => _joinBlock.Target1;
        public ITargetBlock<T2> Target2 => _joinBlock.Target2;
        public Task Completion => _joinBlock.Completion;
        public SynchronizedJoinBlock(Func<T1, T2, int> compareFunction)
            : this(compareFunction, new GroupingDataflowBlockOptions())
        {
        }
        public SynchronizedJoinBlock(Func<T1, T2, int> compareFunction,
            GroupingDataflowBlockOptions dataflowBlockOptions)
        {
            if (compareFunction == null)
            {
                throw new ArgumentNullException(nameof(compareFunction));
            }
            if (dataflowBlockOptions == null)
            {
                throw new ArgumentNullException(nameof(dataflowBlockOptions));
            }
            if (dataflowBlockOptions.BoundedCapacity > 0)
            {
                throw new NotSupportedException();
            }
            if (!dataflowBlockOptions.Greedy)
            {
                throw new NotSupportedException();
            }
            _compareFunction = compareFunction;
            _joinBlock = new JoinBlock<T1, T2>(dataflowBlockOptions);
            var sharedResources = GetFieldValue<object>(_joinBlock, "_sharedResources");
            var joinFilledActionFieldInfo = sharedResources.GetType().GetField(
                "_joinFilledAction", BindingFlags.NonPublic | BindingFlags.Instance);
            Action action = () =>
            {
                AddMessageToSourceRecursive(
                    _target1Messages.Peek(), _target2Messages.Peek());
            };
            joinFilledActionFieldInfo.SetValue(sharedResources, action);
            _target1Messages = GetFieldValue<Queue<T1>>(Target1, "_messages");
            _target2Messages = GetFieldValue<Queue<T2>>(Target2, "_messages");
            var source = GetFieldValue<object>(_joinBlock, "_source");
            var addMessageMethodInfo = source.GetType().GetMethod(
                "AddMessage", BindingFlags.NonPublic | BindingFlags.Instance);
            _addMessageToSource = (value) =>
            {
                addMessageMethodInfo.Invoke(source, new[] { value });
            };
        }
        private static TResult GetFieldValue<TResult>(object instance, string fieldName)
        {
            var fieldInfo = instance.GetType().GetField(
                fieldName, BindingFlags.NonPublic | BindingFlags.Instance);
            return (TResult)fieldInfo.GetValue(instance);
        }
        private void AddMessageToSourceRecursive(T1 value1, T2 value2)
        {
            int result = _compareFunction(value1, value2);
            if (result == 0)
            {
                _addMessageToSource(Tuple.Create(
                    _target1Messages.Dequeue(), _target2Messages.Dequeue()));
            }
            else if (result < 0)
            {
                _addMessageToSource(
                    Tuple.Create(_target1Messages.Dequeue(), default(T2)));
                if (_target1Messages.Count > 0)
                {
                    AddMessageToSourceRecursive(_target1Messages.Peek(), value2);
                }
            }
            else
            {
                _addMessageToSource(
                    Tuple.Create(default(T1), _target2Messages.Dequeue()));
                if (_target2Messages.Count > 0)
                {
                    AddMessageToSourceRecursive(value1, _target2Messages.Peek());
                }
            }
        }
        public void Complete()
        {
            _joinBlock.Complete();
        }
        Tuple<T1, T2> ISourceBlock<Tuple<T1, T2>>.ConsumeMessage(
            DataflowMessageHeader messageHeader,
            ITargetBlock<Tuple<T1, T2>> target, out bool messageConsumed)
        {
            return ((ISourceBlock<Tuple<T1, T2>>)_joinBlock)
                .ConsumeMessage(messageHeader, target, out messageConsumed);
        }
        void IDataflowBlock.Fault(Exception exception)
        {
            ((IDataflowBlock)_joinBlock).Fault(exception);
        }
        public IDisposable LinkTo(ITargetBlock<Tuple<T1, T2>> target,
            DataflowLinkOptions linkOptions)
        {
            return _joinBlock.LinkTo(target, linkOptions);
        }
        void ISourceBlock<Tuple<T1, T2>>.ReleaseReservation(
            DataflowMessageHeader messageHeader, ITargetBlock<Tuple<T1, T2>> target)
        {
            ((ISourceBlock<Tuple<T1, T2>>)_joinBlock)
                .ReleaseReservation(messageHeader, target);
        }
        bool ISourceBlock<Tuple<T1, T2>>.ReserveMessage(
            DataflowMessageHeader messageHeader, ITargetBlock<Tuple<T1, T2>> target)
        {
            return ((ISourceBlock<Tuple<T1, T2>>)_joinBlock)
                .ReserveMessage(messageHeader, target);
        }
        public bool TryReceive(Predicate<Tuple<T1, T2>> filter, out Tuple<T1, T2> item)
        {
            return _joinBlock.TryReceive(filter, out item);
        }
        public bool TryReceiveAll(out IList<Tuple<T1, T2>> items)
        {
            return _joinBlock.TryReceiveAll(out items);
        }
    }
