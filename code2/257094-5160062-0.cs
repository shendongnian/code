    class ViewBase<TPresenter, TView>
        where TPresenter : Presenter<TView>, new()
        where TView : IView, new()
    {
        public TPresenter Presenter { get; private set; }
        void CreatePresenter()
        {
            this.Presenter = new TPresenter();
            this.Presenter.View = new TView();
        }
    }
