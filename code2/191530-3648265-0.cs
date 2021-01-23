    class Program
    {
        static void Main(string[] args)
        {
            List<Record> records = new List<Record>()
            {
                new Record() { id = 1,  value = 0},
                new Record() { id = 2,  value = 1 },
                new Record() { id = 3,  value = 2 },
                new Record() { id = 4,  value = 3 },
                new Record() { id = 5,  value = 4 },
                new Record() { id = 6,  value = 2 },
                new Record() { id = 7,  value = 3 },
                new Record() { id = 8,  value = 1 },
                new Record() { id = 9,  value = 0 },
                new Record() { id = 10, value = 4 }
            };
    
            var query = from r in records
                        group r by r.value into g
                        select new {Count = g.Count(), Value = g.Key};
    
            foreach (var v in query)
            {
                Console.WriteLine("Value = {0}, Count = {1}", v.Value, v.Count);
            }
        }
    }
