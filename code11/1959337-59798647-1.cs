        public class MYMODULE: AbpModule
            {
                Timer timer;
                private static readonly ILog log = LogManager.GetLogger(typeof(MYMODULE));
                public override void PreInitialize()
                {
                    log.Error("MyMessage");
                }
            }
