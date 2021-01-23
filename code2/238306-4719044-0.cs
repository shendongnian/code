    foreach (NHibernate.Cfg.Configuration cfg in ActiveRecordMediator.GetSessionFactoryHolder().GetAllConfigurations())
            {
                cfg.SetListener(ListenerType.Delete, new SoftDeleteListener());
                cfg.AddAssembly(assem);
            }
