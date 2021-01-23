    public class Foo : IEnumerable<Bar>
    {
        public IEnumerator<Bar> GetEnumerator()
        {
            // Use yield return here, or 
            // just return Values.GetEnumerator()
        }
        // Explicit interface implementation for non-generic
        // interface; delegates to generic implementation.
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
