    public class CaseInSensitiveDictionary<TValue> : Dictionary<string, TValue> 
    {
        public CaseInSensitiveDictionary():base(StringComparer.OrdinalIgnoreCase)
        {
        }
    }
