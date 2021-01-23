        private IEnumerable<MethodInfo> MethodsToIntercept()
        {
            return typeToIntercept.GetInterfaces()
                .SelectMany(t => t.GetMethods())
                .Union(typeToIntercept.GetMethods())
                .Where(m => !m.IsSpecialName);
        }
        private IEnumerable<PropertyInfo> PropertiesToIntercept()
        {
            return typeToIntercept.GetInterfaces()
                .SelectMany(t => t.GetProperties())
                .Union(typeToIntercept.GetProperties());
        }
        private IEnumerable<EventInfo> EventsToIntercept()
        {
            return typeToIntercept.GetInterfaces()
                .SelectMany(t => t.GetEvents())
                .Union(typeToIntercept.GetEvents());
        }
