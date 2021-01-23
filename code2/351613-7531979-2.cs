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
            p.Add(new Person() { Name = "Donna Doe", Gender = "Female" });
            p.Add(new Person() { Name = "UnDoe",  });
    
            // test 1
            foreach (var item in p.GroupBy(x => x.Gender))
                Console.WriteLine(item.Count() + " " + item.Key);
            Console.WriteLine(Environment.NewLine);
            
            //test 2
            foreach (var item in p)
                Console.WriteLine(item.Name + "\t" + item.Gender);
            
            Console.ReadLine();
        }
    }
