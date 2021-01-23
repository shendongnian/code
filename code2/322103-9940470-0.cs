			kernel.Bind<ILog>().ToMethod( context=> 
				LogManager.GetLogger( context.Request.Target.Member.ReflectedType ) );
			kernel.Get<LogCanary>();
		}
		class LogCanary
		{
			public LogCanary(ILog log)
			{
				log.Debug( "Debug Logging Canary message" );
				log.Info( "Logging Canary message" );
			}
		}
