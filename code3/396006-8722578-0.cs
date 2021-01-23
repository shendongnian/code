        public class LastNameComparer : IEqualityComparer<Test>
        {
            public bool Equals(Test x, Test y)
            {
                if (x == null)
                    return y == null;
                return x.lastname == y.lastname;
            }
            public int GetHashCode(Test obj)
            {
                if (obj == null)
                    return 0;
                return obj.lastname.GetHashCode();
            }
        }
