        public static IMapBuilderContext<TResult> MapAllProperties()
        {
            IMapBuilderContext<TResult> context = new MapBuilderContext();
            var properties =
                from property in typeof(TResult).GetProperties(BindingFlags.Instance | BindingFlags.Public)
                where IsAutoMappableProperty(property)
                select property;
            foreach (var property in properties)
            {
                context = context.MapByName(property);
            }
            return context;
        }
