    public class StringDoubleCollection
    {
        private List<KeyValuePair<string, double>> myValues;
        public List<double> values
        {
            get { return myValues.Select(keyValuePair => keyValuePair.Value).ToList(); }
        }
        public void add(string key, double value)
        {
            myValues.Add(new KeyValuePair<string,double>(key,value));
        }
    }
