    class Bootstrapper : AutofacBootstrapper 
    {
        public Container ConfigureContainerBuilder()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<ServiceControllerWorker>().As<IServiceControllerWorker>().SingleInstance();
            builder.RegisterType<NotifyIconViewModel>().As<INotifyIconViewModel>().SingleInstance();
            builder.RegisterType<TaskbarIcon>().SingleInstance();
            builder.RegisterType<MainWindow>().SingleInstance();
            return builder.Build();
        }
    }
