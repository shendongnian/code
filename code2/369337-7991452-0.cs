    public class MySection : ConfigurationSection
    {
        public MyElementCollection Elements { ... }
    }
    
    public class MyElementCollection : ConfigurationElementCollection, 
                                       IEnumerable<ConfigurationElement> // most important difference with default solution
    {
        ...
    }
    
    public class MyElement : ConfigurationElement
    {
        public int Value { ... }
    }
