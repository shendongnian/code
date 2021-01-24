    public class A
    {
        public A()
        {
            Level = "D3";
        }
        public string Level { get; set; }
        public B B { get; set; }
    }
    public class B
    {
        [Level("MyNamespace.A.Level")]
        public int? OrderNumber { get; set; }
    }
    public class LevelAttribute : ValidationAttribute
    {
        private string PropName { get; set; }
        public LevelAttribute(string prop)
        {
            this.PropName = prop;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            System.Reflection.PropertyInfo property = null;
            object objectinstance = null;
            if (this.PropName.Contains("."))
            {
                string classname = PropName.Substring(0, PropName.LastIndexOf("."));
                string prop = PropName.Substring(PropName.LastIndexOf(".") + 1);
                Type type = Type.GetType(classname);
                objectinstance = System.Activator.CreateInstance(type);
                property = type.GetProperty(prop, System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.NonPublic);
            }
            else
            {
                objectinstance = validationContext.ObjectInstance;
                property = validationContext.ObjectInstance.GetType().GetProperty(this.PropName, System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.NonPublic);
            }
            object propertyvalue = property.GetValue(objectinstance, new object[0]);
            if (value != null && propertyvalue != null && (propertyvalue.Equals("D1") || propertyvalue.Equals("D2")))
            {
                return new ValidationResult("Invalid Error Message");
            }
            return ValidationResult.Success;
        }
    }
 
