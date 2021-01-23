        using Newtonsoft.Json;
        ...
        public class Person
        {
            public string Name { get; set; }
            public DateTime Birthday { get; set; }
        }
        void PersonToJsonToPersonExample ()
        {
            var person = new Person { Name = "Bob", Birthday = new DateTime (1987, 2, 2) };
            var json = JsonConvert.SerializeObject (person);
            Console.WriteLine ("JSON representation of person: {0}", json);
            var person2 = JsonConvert.DeserializeObject<Person> (json);
            Console.WriteLine ("{0} - {1}", person2.Name, person2.Birthday);
        }
