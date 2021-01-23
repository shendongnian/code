    public class ArrComparer : IComparer
    {
        public int Compare(object x, object y)
        {
            string left = x.ToString();
            string right = y.ToString();
            // Note I assumed indexes since yours were overlapping.
            string lage = left.Substring(0, 3);
            string lname = left.Substring(3, 3);
            string lamt = left.Substring(7, 3);
            string rage = left.Substring(0, 3);
            string rname = left.Substring(3, 3);
            string ramt = left.Substring(7, 3);
            // Compare name first, if one is greater return
            int result = lname.CompareTo(rname);
            if (result != 0)
                return result;
            // else compare age, if one is greater return
            result = lage.CompareTo(rage)
            if (result != 0)
                return result;
            // else compare amt if one is greater return
            result = lamt.CompareTo(ramt)
            if (result != 0)
                return result;
            // else they are equal
            return 0;
        }
    }
