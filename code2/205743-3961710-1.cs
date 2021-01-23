    public class Foo : IEnumerable<Bar>
    {
        .. your existing code goes here
    
        public IEnumerator<Bar> GetEnumerator()
        {
            return Bar.GetEnumerator();
        }
    
        IEnumerator IEnumerable.GetEnumerator()
        {
            return Bar.GetEnumerator();
        }
    }
