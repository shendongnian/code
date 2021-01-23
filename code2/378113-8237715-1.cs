    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Reflection;
    
    namespace Nullable_Demo
    {
        class Test
        {
            public int? value { get; set; }
        }
        class Program
        {
            static void Main(string[] args)
            {
                var obj = new Test { value = 10 };
                //var fld = typeof(Test).GetField("value");
                //var v = fld.GetValue(obj);
    
                Type typeobjs = obj.GetType();
                PropertyInfo[] piObjs = typeobjs.GetProperties();
    
                foreach (PropertyInfo piObj in piObjs)
                {
                    Type typeDefinedInNullable;
    
                    // Test for Nullable
                    bool isNullable = piObj.PropertyType.IsGenericType &&
                        piObj.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>);
    
                    if (isNullable)
                    {
                        // Returns the basic data type without reference to Nullable (for example, System.Int32)
                        typeDefinedInNullable = piObj.PropertyType.GetGenericArguments()[0];
                    }
                }
            }
        }
    
    }
