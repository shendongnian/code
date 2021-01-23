    interface IDummyInterface
    {
        void OnCreate();
        void Process();
        void OnFinish();
    }
    abstract class DummyAbstract : IDummyInterface
    {
        public virtual void OnCreate()
        {
        }
        public abstract void Process();
        public void OnFinish()
        {
            OnFinishInternal();
        }
        protected abstract void OnFinishInternal();
    }
    class DummyImplementor : DummyAbstract
    {
        public override void OnCreate()
        {
            // some other action here
            base.OnCreate();
        }
        public override void Process()
        {
        }
        protected override void OnFinishInternal()
        {
        }
    }
