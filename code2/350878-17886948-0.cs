        ...
        private static _objectContext;
        protected void Page_Init(object sender, EventArgs e)
        {
            _objectContext = new ObjectContext();
        }
        ...
        protected void _ContextCreating(object sender, EntityDataSourceContextCreatingEventArgs e)
        {
            e.Context = _objectContext;
        }
        protected void _ContextDisposing(object sender, EntityDataSourceContextDisposingEventArgs e)
        {
            e.Cancel = true;
        }
