    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Reflection;
    
    public static class Program
    {
        static void Main()
        {
            PropertyInfo prop = typeof(Foo).GetProperty("Bar");
            var vals = GetPropertyAttributes(prop);
            // has: DisplayName = "abc", Browsable = false
        }
        public static Dictionary<string, object> GetPropertyAttributes(PropertyInfo property)
        {
            Dictionary<string, object> attribs = new Dictionary<string, object>();
            // look for attributes that takes one constructor argument
            foreach (CustomAttributeData attribData in property.GetCustomAttributesData()) 
            {
                
                if(attribData.ConstructorArguments.Count == 1)
                {
                    string typeName = attribData.Constructor.DeclaringType.Name;
                    if (typeName.EndsWith("Attribute")) typeName = typeName.Substring(0, typeName.Length - 9);
                    attribs[typeName] = attribData.ConstructorArguments[0].Value;
                }
                
            }
            return attribs;
        }
    }
    
    class Foo
    {
        [DisplayName("abc")]
        [Browsable(false)]
        public string Bar { get; set; }
    }
