       public class Record
        {
            public int Id { get; set; }
            public DateTime Date { get; set; }
            public DateTime StartTime { get; set; }
            public DateTime EndTime { get; set; }
            public List<List<Record>> GroupRecords(List<Record> data, DateTime start, DateTime end)
            {
                return data
                    .Where(x => (x.Date > start) && (x.Date < end)) 
                    .GroupBy(x => x.Date.Date).Select(y => y.ToList()).ToList();
            }
        }
