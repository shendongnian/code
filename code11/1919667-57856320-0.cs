        static void Main(string[] args)
        {
            string json = "{\"Email\": \"james@example.com\",\"Active\": true,\"CreatedDate\": \"2013-01-20T00:00:00Z\",\"Roles\": [\"User\", \"Admin\"]}";
            House result = JsonConvert.DeserializeObject<House>(json);
            Console.WriteLine($"{result.Email} ");
        }
        public class House
        {
            public string Email { get; set; }
            public bool Active { get; set; }
            public DateTime CreatedDate { get; set; }
            public List<string> Roles { get; set; }
        }
