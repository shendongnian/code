    public MyView : IMyView
    {
        private IMyPresenter _myPresenter;
        public string Title { get { return _myPresenter.GetTitle(); } }
    }
