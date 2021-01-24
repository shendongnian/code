    public NewViewModel NewView
    {
        get
        {
            SimpleIoc.Default.Unregister<NewViewModel>();
            SimpleIoc.Default.Register<NewViewModel>(true);
            var vm = ServiceLocator.Current.GetInstance<NewViewModel>();
            vm.Initialize();
            return vm;
        }
    }
