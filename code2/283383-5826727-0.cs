        static int Compare(object a, object b)
        {
            if (a == null)
            {
                return b == null ? 0 : 1;
            }
            if (b == null)
            {
                return -1;
            }
            return a.GetHashCode().CompareTo(b.GetHashCode());
        }
