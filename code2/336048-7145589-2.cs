    struct Info
    {
        public string Name { get; set; }
        public float Percent { get; set; }
    }
    class Statistics
    {
        public IEnumerable&ltstring&gt CreateSampleSet(int sampleSize, params Info[] infos)
        {
            var rnd = new Random();
            var result = new List&ltstring&gt();
            infos = infos.OrderByDescending(x =&gt x.Percent).ToArray();
            foreach (var info in infos)
            {
                for(var _ = 0; _ &lt (int)(info.Percent/100.0*sampleSize); _++)
                result.Add(info.Name);
            }
            if (result.Count &lt sampleSize)
            {
                while (result.Count &lt sampleSize)
                {
                    var p = rnd.NextDouble()*100;
                    var value = infos.First(x =&gt x.Percent &lt= p);
                    result.Add(value.Name);
                }
            }
            return result;
        }
    }
