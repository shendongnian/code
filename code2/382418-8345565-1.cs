    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    class ObjectA
    {
        public string FieldA { get; set; }
        public string FieldB { get; set; }
        public string FieldC { get; set; }
    }
    
    class ObjectB
    {
        public string FieldA { get; set; }
        public string FieldB { get; set; }
        public string FieldC { get; set; }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            ObjectA a = new ObjectA() { FieldA = "test", FieldB = "test2", FieldC = "test3" };
            ObjectB b = new ObjectB() { FieldA = "test", FieldB = "test2", FieldC = "test3" };
    
            if (a.ComparePropertiesTo(b))
            {
                Console.WriteLine("objects have the same properties");
            }
            else
            {
                Console.WriteLine("objects have diferent properties!");
            }
    
            Console.Read();
        }
    }
    
    public static class Utilities
    {
        public static bool ComparePropertiesTo(this Object a, Object b)
        {
            System.Reflection.PropertyInfo[] properties = a.GetType().GetProperties(); // get all the properties of object a
    
            foreach (var property in properties)
            {
                var propertyName = property.Name;
    
                var aValue = a.GetType().GetProperty(propertyName).GetValue(a, null);
                object bValue;
    
                try // try to get the same property from object b. maybe that property does
                    // not exist! 
                {
                    bValue = b.GetType().GetProperty(propertyName).GetValue(b, null);
                }
                catch
                {
                    return false;
                }
    
                // if properties do not match return false
                if (aValue.GetHashCode() != bValue.GetHashCode())
                {
                    return false;
                }
            }
    
            return true;
        }
    }
