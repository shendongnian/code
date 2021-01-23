    public static partial class ReferenceData
    {
        public static string GetDatastoreText(string datastoreValue)
        {
            return GetDatastore().Single(s => s.Value == datastoreValue).Text;
        }
        public static string GetDatastoreValue(string datastoreText)
        {
            return GetDatastore().Single(s => s.Text == datastoreText).Value;
        }
    }
