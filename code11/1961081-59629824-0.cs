    using System;
    using System.Reflection;
    using System.ComponentModel;
    
    public class Program
    {
        public static void Main()
        {
            var wantedObject = MyHelper.FillData<Student>();
            Console.WriteLine(wantedObject.Gender);
        }
    
        public static class MyHelper
        {
            public static T FillData<T>()
            {
                Type type = typeof(T);
                PropertyInfo[] properties = type.GetProperties();
                var resultObject = (T)Activator.CreateInstance(typeof(T), new object[]{});
                foreach (PropertyInfo property in properties)
                {
                    if (property.PropertyType == typeof(string))
                    {
                        property.SetValue(resultObject, "asdf");
                    }
                    else if (property.PropertyType.BaseType.FullName == "System.Enum")
                    {
                       DefaultValueAttribute[] attributes = property.PropertyType.GetCustomAttributes(typeof(DefaultValueAttribute), false) as DefaultValueAttribute[];
                       if (attributes != null && attributes.Length > 0)
    						property.SetValue(resultObject, attributes[0].Value);
    					else
                        //..do something here to get a random value.
    						property.SetValue(resultObject, 0);
                    }
                }
    
                return resultObject;
            }
        }
    
        public class Student
        {
            public string Name{get;set;}
            public string Surname{get;set;}
            public GenderEnum Gender{get;set;}
            public LevelEnum Level{get;set;}
        }
    	
    	[DefaultValue(Male)]
        public enum GenderEnum
        {
            Male = 1,
            Female = 2,
        }
    	
    	[DefaultValue(High)]
        public enum LevelEnum
        {
            High = 1,
            Low = 2,
        }
    }
