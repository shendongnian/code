    public class SomeUnUsefulClass:IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                throw new NotImplementedException();
            }
            public void Add(int i)
            {
                //It does not do anything.
            }
        }
