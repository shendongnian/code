    public class NHibernateModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ISessionFactory>().ToMethod(x => NHibernateHelper.CreateSessionFactory()).InSingletonScope();
            Bind<ISession>().ToMethod(x => NHibernateHelper.GetSession(Kernel.Get<ISessionFactory>()));
        }
    }
