    class Operation
    {
        public DateTime Date { get; set; }
        public int OperationA { get; set; }
        public int OperationB { get; set; }
        public int OperationC { get; set; }
    }
    var operations = LoadData();
    var result = operations.GroupBy(o => o.Date)
                       .Select(g => new Operation
                        {
                            Date = g.Key,
                            OperationA = g.Sum(o => o.OperationA),
                            OperationB = g.Sum(o => o.OperationB),
                            OperationC = g.Sum(o => o.OperationC)
                        });
