    public class DynamicSerializableComparer : IComparer<object>
    {
        string _property;
        public DynamicSerializableComparer(string property)
        {
            _property = property;
        }
        public int Compare(object stringA, object stringB)
        {
            string valueA = stringA.GetType().GetProperty(_property).GetValue();
            string valueB = stringB.GetType().GetProperty(_property).GetValue();
            return String.Compare(valueA, valueB);
        }
    }
