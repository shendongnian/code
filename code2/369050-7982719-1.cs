    public class StringEnumerable : IEnumerable, IEnumerable<String>
    {
        IEnumerator<String> IEnumerable<String>.GetEnumerator()
        {
            yield return "TEST";
        }
        public IEnumerator GetEnumerator()
        {
            // without the explicit cast of `this` to the generic interface the 
            // method would call itself infinitely until a StackOverflowException occurs
            return ((IEnumerable<String>)this).GetEnumerator();
        }
    }
