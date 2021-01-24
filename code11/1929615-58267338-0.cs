        class Program
        {
            static void Main(string[] args)
            {
                List<Person> persons = new List<Person>();
                List<int> searchIds = new List<int> { 1, 2, 3, 4, 5 };
                List<Person> result = persons.Where(p => p.Locations.Any(l => searchIds.Contains(l.Id))).ToList();
            }
        }
        public class Person
        {
            public List<Location> Locations { get; set; }
        }
        public class Location
        {
            public int Id { get; set; }
        }
