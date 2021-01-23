    public abstract RequestDetail
    {
        public void CreateDetail()
        {
            CustomBehavior();
        }
        protected abstract CustomBehavior();
    }
    public RequestDetailA : RequestDetail
    {
        protected override void CustomBehavior()
        {
            // Foo
        }
    }
