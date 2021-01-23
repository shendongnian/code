    public class Nullable
    {
        public class Person
        {
          private string _gender;
          public string Gender
          {
              get {
                  string val = 
                     (!string.IsNullOrEmpty(_gender) ? _gender : "[Not decided yet]");
                  return val; 
              }
              set { _gender = value; }
          }
    
          public string Name { get; set; }
          public string MiddleName { get; set; }
          public string Surname { get; set; }
        }
    
        static void Main()
        {
            List<Person> p = new List<Person>();
            p.Add(new Person() { Name = "John Doe", Gender = "Male" });
            p.Add(new Person() { Name = "Jane Doe", Gender = "Female" });
            p.Add(new Person() { Name = "UnDoe",  });
    
            foreach (var item in p)
                Console.WriteLine(item.Name + "\t\t" + item.Gender);
            
            Console.ReadLine();
        }
    }
