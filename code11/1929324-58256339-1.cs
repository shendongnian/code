    public class Field1Sort: IComparer
    {
        public Field1Sort()
        {
        }
        public int Compare(object x, object y)
        {
            var xString = (string)x;
            var yString = (string)y;
            var date1 = xString.Substring(0, 10).ToDateTime();
            var date2 = yString.Substring(0, 10).ToDateTime();
            if (date1 < date2)
                return -1;
            if (date1 > date2)
                return 1;
            else
                return 0;
        }
    }
