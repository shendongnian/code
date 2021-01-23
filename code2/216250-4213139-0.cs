    builder.RegisterType<ViewRegistry>()
      .As<IViewRegistry>()
      .SingleInstance();
    builder.RegisterType<MyView>()
      .OnActivated(e =>
         e.Context.Resolve<IViewRegistry>().Add(e.Instance))
      .OnRelease(e => {
         e.Instance.Dispose();
         e.Context.Resolve<IViewRegistry>().Remove(e.Instance))
      });
