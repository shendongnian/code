            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            var controllerTypes = assemblies
                .SelectMany(a => a.GetTypes())
                .Where(t => t != null
                    && t.IsPublic
                    && t.Name.EndsWith("Controller", StringComparison.OrdinalIgnoreCase)
                    && !t.IsAbstract
                    && typeof(IController).IsAssignableFrom(t));
            var controllerMethods = controllerTypes.ToDictionary(
                controllerType => controllerType,
                controllerType => controllerType.GetMethods(BindingFlags.Public | BindingFlags.Instance).Where(m => typeof(ActionResult).IsAssignableFrom(m.ReturnType)));
