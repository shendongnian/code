    public class Record
    {
        public string Name { get; set; }
        public double Score1 { get; set; }
        public double Score2 { get; set; }
    }
    var query = from record in Records
                order by ((record.Score1 + record.Score2) / 2) descending
                select new
                       {
                           Name = record.Name,
                           Average = ((record.Score1 + record.Score2) / 2)
                       };
