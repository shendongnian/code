    public class CallingDoSomething
    {
        private Type[] Get_IDoSomethingTypes()
        {
            var allTypes = typeof(CallingDoSomething).Assembly.GetTypes();
            var searchFor = typeof(IDoSomething);
            return allTypes.Where(x => searchFor.IsAssignableFrom(x))
                           .Where(x => x.IsClass)
                           .ToArray();
        }
        public void CallAllSomethings()
        {
            var types = Get_IDoSomethingTypes();
            foreach (var type in types)
            {
                var instance = (IDoSomething)Activator.CreateInstance(type);
                instance.Dosomething();
            }
        }
    }
