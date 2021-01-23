        public class Filter {
            public String Prop { get; set; }
        }
        static void Main(string[] args) {
            var strings = new List<String>();
            var filters = new List<Filter>();
            var result = strings.Select(x => new KeyValuePair<string, Filter>(x,filters.FirstOrDefault(y => y.Prop == x)))
                .ToList();
            Console.ReadLine();
        }
