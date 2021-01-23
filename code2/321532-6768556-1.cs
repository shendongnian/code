    public static class StructureMapBootStrapper
    {
        public static void InitializeStructureMap()
        {
            ObjectFactory.Initialize(x =>
            {
                x.For<IProjectRepository>().Use<ProjectRepository>();
            }
        }
    }
