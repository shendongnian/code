    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Contains(string searchText)
        {
            return Name.Contains(searchText);
        }
    }
