    [AttributeUsage(AttributeTargets.Property)]
    public class FlagValueAttribute : Attribute
    {
         public FlagValueAttribute (int value)
         {
             Value = value;
         }
         public int Value{get;set}
    }
    public class SomeEntity
    {
        [FlagValue(1)]
        public bool HAS_POSITION { get; set; }
    
        [FlagValue(2)]
        public bool HAS_SOURCE { get; set; }
    
        [FlagValue(4)]
        public bool HAS_DESTINATION { get; set; }
        [FlagValue(8)]
        public bool HAS_SUBJECT { get; set; }
    }
    public static class EntityExtensions
    {
    
        public static void FillFlags(this object instance, int combinedFlags )
        {
            foreach (PropertyInfo prop in instance.GetType().GetProperties() )
            {
                 var attr = prop.GetCustomAttribute<FlagValueAttribute>();
                 if (attr == null)
                     continue;
        
                 if ((attr.Value & combinedFlags) != 0)
                     prop.SetValue(instance, true);
            }
        }
    }
