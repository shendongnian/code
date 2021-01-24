    class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person
            {
                Id = 1,
                Name = "test",
                Address = "tost"
            };
            Console.WriteLine(person["Id"]);
            person["Id"] = 5;
            Console.WriteLine(person["Id"]);
        }
    }
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public object this[string propertyName]
        {
            get
            {
                return this.GetType().GetProperty(propertyName).GetValue(this);
            }
            set
            {
                this.GetType().GetProperty(propertyName).SetValue(this, value);
            }
        }
    }
