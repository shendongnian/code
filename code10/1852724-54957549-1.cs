    public class Manager1 : BaseManager
    {
        public override IEnumerable<Statistics> GetStatistics()
        {
            var stats = new List<Statistics>();
            stats.Add(new Statistics { .... });
            stats.Add(new Statistics { .... });
            stats.Add(new Statistics { .... });
            stats.Add(new Statistics { .... });
            return stats;
        }
    }
