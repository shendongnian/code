    public class AutofacInterceptor : NHibernate.EmptyInterceptor
    {
        Autofac.ILifetimeScope scope;
        public AutofacInterceptor(Autofac.ILifetimeScope scope)
        {
            this.scope = scope;
        }
        public override object Instantiate(string entityName, EntityMode entityMode, object id)
        {
            // use the LifetimeScope to instantiate the correct entity
        }
    }
