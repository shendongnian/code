    Presenter = new MyPresenter(this); 
    if (!IsPostback) 
    { 
        using (IMyService service = ServiceFactory.Instance.CreateService<IMyService>())
        {
            presenter.PrepareView(service); 
        } 
    } 
