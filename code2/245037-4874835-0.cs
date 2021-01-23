            protected void Application_Start()
            {
                DependencyResolver.SetResolver(
                    new MyDependencyResolver(
                        new StandardKernel(
                            new MyModule())));
                //...
            }
               
