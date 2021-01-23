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
            foreach (var info in infos)
            {
                for(var _ = 0; _ &lt (int)(info.Percent/100.0*sampleSize); _++)
                result.Add(info.Name);
            }
            while (result.Count &lt sampleSize)
                result.Add(infos[rnd.Next(0, infos.Length)].Name);
            return result;
        }
    }
