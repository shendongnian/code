    public static class StructureMapBootStrapper
    {
        public static void BootStrap()
        {
            StructureMap.ObjectFactory.Initialize(
                bootStrapper =>
                {
                    bootStrapper.For<ISomeThing>().Use<SomeThingOne>();
                });
        }
    }
