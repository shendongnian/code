    public MyPresenter : IMyPresenter
    {
        private IMyView _myView;
        public string GetTitle()
        {
            return ResourceManager["titleResource"];
        }
    }
