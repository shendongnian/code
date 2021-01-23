    public class ActionWrapper<TTypeA>
    {
        protected readonly Action _original;
        public ActionWrapper(Action original)
        {
            _original = original;
        }
        public Action<TTypeA> Wrapped { get { return WrappedAction; } }
        private void WrappedAction(TTypeA a)
        {
            _original();
        }
    }
    public class ActionWrapper<TTypeA,TTypeB>:ActionWrapper<TTypeA>
    {
        public ActionWrapper(Action original) : base(original)
        {
        }
        public new Action<TTypeA, TTypeB> Wrapped { get { return WrappedAction; } }
        private void WrappedAction(TTypeA a,TTypeB b)
        {
            _original();
        }
    }
