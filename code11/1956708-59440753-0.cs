    public class BComparer : IEqualityComparer<B>
    {
        public bool Equals([AllowNull] B x, [AllowNull] B y)
        {
            if (x is null || y is null)  {return false;}
            
            if (x.ID == y.ID) {
                return x.Children.SequenceEqual(y.Children);
            } else {
                return false;
            }
        }
        public int GetHashCode([DisallowNull] B obj)
        {
            return obj.ID.ToString().GetHashCode();
        }
    }
