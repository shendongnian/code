    using System;
    using System.Reflection;
    
    [AttributeUsage(AttributeTargets.Property)]
    public class TableAttribute : Attribute
    {
        public string HeaderText { get; set; }
    }
    
    public class Person
    {
        [Table(HeaderText="F. Name")]
        public string FirstName { get; set; }
        
        [Table(HeaderText="L. Name")]
        public string LastName { get; set; }
    }
    
    public class Test 
    {
        public static void Main()
        {
            foreach (var prop in typeof(Person).GetProperties())
            {
                var attrs = (TableAttribute[]) prop.GetCustomAttributes
                    (typeof(TableAttribute), false);
                foreach (var attr in attrs)
                {
                    Console.WriteLine("{0}: {1}", prop.Name, attr.HeaderText);
                }
            }
        }
    }
