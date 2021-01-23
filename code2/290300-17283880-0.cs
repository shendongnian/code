    kernel.Bind<IObject>().To<Object1>().When(
               x => x.ParentContext != null && !x.ParentContext.Binding.IsConditional)
              .InRequestScope();
            
    kernel.Bind<IObject>().To<Object2>().InRequestScope()
              .Named("WCFSession");
