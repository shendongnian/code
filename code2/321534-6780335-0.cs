    using System.Web.Mvc;
    using YourAppNamespace.Website.IoC;
    using StructureMap;
    [assembly: WebActivator.PreApplicationStartMethod(typeof(YourAppNamespace.App_Start.StructuremapMvc), "Start")]
    namespace YourAppNamespace.Website.App_Start {
        public static class StructuremapMvc {
            public static void Start() {
                var container = SmIoC.Initialize();
                DependencyResolver.SetResolver(new SmDependencyResolver(container));
            }
        }
    }
