    public class SubjectComparer : IEqualityComparer<Subject>
    {
        public bool Equals(Subject x, Subject y)
        {
            if (x == null && y == null)
            {
                return true;
            }
            else if (x == null || y == null)
            {
                return false;
            }
            else
            {
                return x.SubjectName == y.SubjectName;
            }
        }
        public int GetHashCode(Subject obj)
        {
            return obj.SubjectName.GetHashCode();
        }
    }
