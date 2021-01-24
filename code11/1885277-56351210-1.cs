    public interface IGpasData
    {
        void Populate(string[] values);
    }
    public class GpasBar
    {
        public string MyPropertyA { get; set; }
        public int MyPropertyB { get; set; }
    
        public void Populate(string[] values)
        {
            MyPropertyA = values[0];
            MyPropertyB = int.Parse(values[1]);
        }
    }
    public static List<T> ConvertCloudFileToList<T>(string fileName, string modelName)
        where T : IGpasData, new()
    {
        // ...
        using (StreamReader reader = new StreamReader(cloudFile.OpenRead()))
        {
            var results = new List<T>();
            while (!reader.EndOfStream)
            {
                var item = new T();
                item.Populate(reader.ReadLine().Split(','));
    
                results.Add(item);
            }
            return results;
        }
    }
