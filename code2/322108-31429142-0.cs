    public class LoggingModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ILog>().ToMethod(x => LogManager.GetLogger(x.Request.Target.Member.DeclaringType));
            Bind<ILogger>().To<Log4NetLogger>()
                .InSingletonScope();
        }
    }
