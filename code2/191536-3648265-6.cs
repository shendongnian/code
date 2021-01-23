    class Record
    {
        public int Id { get; set; }
        public int Value { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Record> records = new List<Record>()
            {
                new Record() { Id = 1,  Value = 0},
                new Record() { Id = 2,  Value = 1 },
                new Record() { Id = 3,  Value = 2 },
                new Record() { Id = 4,  Value = 3 },
                new Record() { Id = 5,  Value = 4 },
                new Record() { Id = 6,  Value = 2 },
                new Record() { Id = 7,  Value = 3 },
                new Record() { Id = 8,  Value = 1 },
                new Record() { Id = 9,  Value = 0 },
                new Record() { Id = 10, Value = 4 }
            };
    
            var query = from r in records
                        group r by r.Value into g
                        select new {Count = g.Count(), Value = g.Key};
    
            foreach (var v in query)
            {
                Console.WriteLine("Value = {0}, Count = {1}", v.Value, v.Count);
            }
        }
    }
