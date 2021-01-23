    class Presenter
    {
        public Presenter(IView, IDiContainerAbstraction container)
        ...
    }
    Presenter = new MyPresenter(this, unityContainer); 
    public void PrepareView()      
    {  
        using (IMyService service = this.unityContainer.Resolve<IMyService>())
        {
            View.Data = service.GetData();  
        }
    }
