    public class A<TItem>
        {
            public void Method(IEnumerable<TItem> sequence)
            {
            }
        }
        // TObject can be everyone type. It is not contrained.
        public class B<TObject>
        {
            public void Method(TObject obj)
            {
                // Assume that we ensured that obj is IEnumerable<>, but how to create instance of A?
                // May be there is another way to solve this problem...
                A<dynamic> f = new A<dynamic>();
                IEnumerable<string> list = new List<string>();
                f.Method(list);
            }
        }
