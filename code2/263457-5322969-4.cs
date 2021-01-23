    public class Person
    {
        public string Name { get; set; }
    
        public List<Person> GetAll()
        {
            List<Person> names = new List<Person>;
            string[] namesArray = ConfigurationManager.AppSettings["UserNames"].Split(',');
            foreach(var name in namesArray)
            {
                names.Add(new Person { Name = name });
            }
            return names;
        }
    }
