        public override IEnumerable<Statistics> GetStatistics()
        {
            var stats = new List<Statistics>();
            stats.Add(new Statistics { .... });
            stats.Add(new Statistics { .... });
            stats.Add(new Statistics { .... });
            stats.Add(new Statistics { .... });
            
            foreach(var stat in stats)
            {
                yield return stat;
            }
        }
