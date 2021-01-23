            var assemblies = AppDomain.CurrentDomain.GetAssemblies(); // currently loaded assemblies
            var controllerTypes = assemblies
                .SelectMany(a => a.GetTypes())
                .Where(t => t != null
                    && t.IsPublic // public controllers only
                    && t.Name.EndsWith("Controller", StringComparison.OrdinalIgnoreCase) // enfore naming convention
                    && !t.IsAbstract // no abstract controllers
                    && typeof(IController).IsAssignableFrom(t)); // should implement IController (happens automatically when you extend Controller)
            var controllerMethods = controllerTypes.ToDictionary(
                controllerType => controllerType,
                controllerType => controllerType.GetMethods(BindingFlags.Public | BindingFlags.Instance).Where(m => typeof(ActionResult).IsAssignableFrom(m.ReturnType)));
