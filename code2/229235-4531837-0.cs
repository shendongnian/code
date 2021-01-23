    public class MyObjectDataSource : ObjectDataSource
    {
        private MyObjectDataSourceView _view;
        private MyObjectDataSourceView GetView()
        {
            if (_view == null)
            {
                _view = new MyObjectDataSourceView(this, "DefaultView", Context);
                if (IsTrackingViewState)
                {
                    ((IStateManager)_view).TrackViewState();
                }
            }
            return _view;
        }
        protected override DataSourceView GetView(string viewName)
        {
            return GetView();
        }
    }
    public class MyObjectDataSourceView : ObjectDataSourceView
    {
        public MyObjectDataSourceView(MyObjectDataSource owner, string name, HttpContext context)
            : base(owner, name, context)
        {
        }
        protected override IEnumerable ExecuteSelect(DataSourceSelectArguments arguments)
        {
            IEnumerable dataSource = base.ExecuteSelect(arguments);
            // TODO: do your stuff here
            return dataSource;
        }
    }
