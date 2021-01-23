        public interface IAddable<T> {
            T Add(T other);
        }
         
        public struct Integer : IAddable<Integer> {
            public int Value;
            public Integer(int value) { Value = value; }
            public Integer Add(Integer other) { return new Integer(Value + other.Value); }
        }
        // then instead of
        Generic<int> blah = ...;
        // have to write:
        Generic<Integer> blah = ...;
