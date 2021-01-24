    class C<T>
    {
        private readonly ActionBlock<T> _actionBlock;
        public C(Action<T> action)
        {
            _actionBlock = new ActionBlock<T>(action);
        }
        public void Do(T item)
        {
            var accepted = _actionBlock.Post(item);
            Debug.Assert(accepted);
        }
    }
