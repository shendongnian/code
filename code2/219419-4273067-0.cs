    public class SpecialClass
    {
        private static Dictionary<string, Func<SpecialClass>> factories =
            new Dictionary<string, Func<SpecialClass>>();
    
        static SpecialClass()
        {
            factories["Read"] = () => new ReadSpecialClass();
            factories["Write"] = () => new WriteSpecialClass();
        }
    
        public static SpecialClass CreateByName(string name)
        {
            Func<SpecialClass> factory;
    
            if (!factories.TryGetValue(name))
                throw new ArgumentException("name", "\"" name +
                    "\" is not a recognized subclass of SpecialClass.");
    
            return factory();
        }
    }
