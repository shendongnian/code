    protected SessionWrapper sessionWrapper;
    public BaseController()
            {
                Services = new Services();
                sessionWrapper = new SessionWrapper.Instance;
            }
