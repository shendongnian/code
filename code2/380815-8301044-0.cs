    using System; 
    using System.Reflection; 
    
        class Program
        {
            static void Main(string[] args)
            {
                Person person = new Person();
                person.Age = 27;
                person.Name = "Fernando Vezzali";
        
                Type type = typeof(Person);
                PropertyInfo[] properties = type.GetProperties();
                foreach (PropertyInfo property in properties)
                {
                    Console.WriteLine("{0} = {1}", property.Name, property.GetValue(person, null));
                }
        
                Console.Read();
            }
        }
