        public class MyModule : NinjectModule
        {
            public override void Load()
            {
                Bind<IDepartmentsRepository>().To<DepartmentsRepository>();
            }
        }
