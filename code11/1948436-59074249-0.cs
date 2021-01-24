    internal class Program
    {
        private static void Main(string[] args)
        {
            using (StreamReader r = new StreamReader(@"pathtoJson"))
            {
                string json = r.ReadToEnd();
                var person = JsonConvert.DeserializeObject<List<Person>>(json);
                System.Console.WriteLine(person[0].Name);
            }
        }
    }
    internal class Person
    {
        public string CarPlateNumber { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
    }
 
