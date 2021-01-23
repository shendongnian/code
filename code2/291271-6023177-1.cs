    protected override DependencyObject CreateShell()
    {
        Thor.Application.Views.ShellView view = new Thor.Application.Views.ShellView();
        _container.Register(Castle.MicroKernel.Registration.Component.For<Thor.Application.Views.ShellView>().Instance(view));
        // _container.Resolve<Thor.Application.Views.ShellView>();
        return view;
    }
