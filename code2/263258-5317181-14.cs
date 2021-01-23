    public class ArrComparer : IComparer
    {
        public int Compare(object x, object y)
        {
            int result;
            string left = x.ToString();
            string right = y.ToString();
            string lhs1 = left.Substring(3, 3);
            string rhs1 = right.Substring(3, 3);
            result = lhs1.CompareTo(rhs1);
            if (result == 0)
            {
               int lhs2 = int.Parse(left.Substring(0,3));
               int rhs2 = int.Parse(right.Substring(0,3));
               result = lhs2.CompareTo(rhs2);
            }
            if (result == 0)
            {
                double lhs3 = double.Parse(left.Substring(6,4));
                double rhs3 = double.Parse(right.Substring(6,4));
                result = rhs3.CompareTo(lhs3);
            }
            return result;
        }
    }
