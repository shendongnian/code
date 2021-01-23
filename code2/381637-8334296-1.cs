    public Presenter1 Presenter { get; set; }
    public MyPage1() 
    {
        ObjectFactory.BuildUp(this);
        this.Presenter.View = this;
    }
