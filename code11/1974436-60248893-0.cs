    public NewViewModel NewView
    {
        get
        {
            var vm = ServiceLocator.Current.GetInstance<NewViewModel>();
            vm.Initialize();
            return vm;
        }
    }
