    public class Operator
    {
         public string Key { get; set; }
         public string Caption { get; set; }
         ...
    
        public static Operator GreaterThan { get { ... } }
        public static Operator LessThan { get { ... } }  
    
        public static IList<Operator> Operators { get { ... } }
    }
