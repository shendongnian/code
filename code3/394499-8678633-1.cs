    Presenter = new MyPresenter(this); 
    if (!IsPostback) 
    { 
        using (IMyService service = unityContainer.Resolve<IMyService>())
        {
            presenter.PrepareView(service); 
        } 
    } 
