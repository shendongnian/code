     private static void Bootstrap()
            {
                // Create the container as usual.
                container = new Container();
               // container.Options.DefaultScopedLifestyle =  new  AsyncScopedLifestyle();
    
                // Register your types, for instance:
                container.Register<IStudentService, StudentService>(Lifestyle.Singleton);
                //container.Register<IUserContext, WinFormsUserContext>();
                container.Register<IStudentRepository, StudentRepository>(Lifestyle.Singleton);
                container.Register<Form1>(Lifestyle.Singleton);
    
                // Optionally verify the container.
                container.Verify();
    
            }
