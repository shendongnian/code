    public class DiagnosticsSettings : IEnumerable
    {
        // ...
        public void Add(string arg1, string arg2)
        {
            _dict.Add(arg1, arg2);
        }
    
        IEnumerator IEnumerable.GetEnumerator()
        {
            return _dict.GetEnumerator();
        }
    }
