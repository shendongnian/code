    public class BaseRichEnum 
    {
       public static InitializeAll()
       {
          foreach (Type t in Assembly.GetExecutingAssembly().GetTypes())
          {
            if (t.IsClass && !t.IsAbstract && typeof (BaseRichEnum).IsAssignableFrom(t))
            {
              t.GetMethod("Initialize").Invoke(null, null); //might want to use flags on GetMethod
            }
          }
       }
    }
    
    public class AbstractEnum<T> : BaseRichEnum where T : AbstractEnum<T>
    {
        static readonly IDictionary<String, T> nameRegistry = new Dictionary<String, T>();
    
        readonly String name;
    
        protected AbstractEnum (String name)
        {
            this.name = name;
            nameRegistry[name] = (T) this;
        }
    
        public String Name {
            get {
                return name;
            }
        }
    
        public static T ValueOf(String name) {
            return nameRegistry[name];
        }
    
        public static IEnumerable<T> Values {
            get {
                return nameRegistry.Values;
            }
        }    
    }
     
