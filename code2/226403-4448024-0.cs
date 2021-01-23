    public abstract class ReadOnlyList : IList
        {
            public bool IsReadOnly { get { return true; } }
            public object this[int index]
            {
                get
                {
                    // there is nothing to put here! Ideally it would be left abstract.
                    throw new NotImplementedException();
                }
                private set
                {
                    // your private implementation
                }
            }
            // other members of IList ...
        }
