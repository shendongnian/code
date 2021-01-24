    public interface IGpasData<T> where T : IGpasData<T>
    {
	    List<T> ConvertToList(StreamReader reader);
    }
    public class GpasBar: IGpasData<GpasBar>
    {
	    public string MyPropertyA { get; set; }
	    public int MyPropertyB { get; set; }
        public List<GpasBar> ConvertToList(StreamReader reader)
        {
            var results = new List<GpasBar>();
            while (!reader.EndOfStream)
            {
                var values = reader.ReadLine().Split(',');
                results.Add(new GpasBar()
                {
                    PropertyA = values[0],
                    PropertyB = int.Parse(values[1]),
                });
            }
            return results;
        }
    }
