        public MyFacade() {
            //Reflect them
            var type = typeof(TopicGenerator);
            var types = AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(s => s.GetTypes())
            .Where(p => type.IsAssignableFrom(p) && !p.IsInterface);
            //Instantiate them
            generators = types.Select(t => Activator.CreateInstance(t) as TopicGenerator).ToList();
        }
