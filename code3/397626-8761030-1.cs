    public abstract IocAwareActionFilterAttribute : ActionFilterAttribute{
        protected T ResolveItem<T>(ResultExecutedContext context)
            {
                var app = context.HttpContext.ApplicationInstance as IInjectableApplication;
                if (app == null) { throw new NullReferenceException("Application is not IInjectable."); }
    
                T c = (T)app.Container.Resolve(typeof(T));
    
                if (c == null) { throw new NullReferenceException(string.Format("Could not find injected {0}.", typeof(T).FullName)); }
                return c;
            }
    
    }
