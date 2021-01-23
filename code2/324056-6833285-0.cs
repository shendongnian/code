    public class DropBoxStringComparer : IComparer<string>
    {
        #region Implementation of IComparer<in string>
        Col2StringComparer col2 = new Col2StringComparer();
        Col6StringComparer col6 = new Col6StringComparer();
        public int Compare(string x, string y)
        {
            char[] tab = new[]{(char) 9};
            string[] xParts = x.Split(tab);
            string[] yParts = y.Split(tab);
            var c6compare = col6.Compare(xParts[5], yParts[5]);
            if (c6compare != 0)
            {
                return c6compare;
            }
            else
            {
                return col2.Compare(xParts[1], yParts[1]);
            }
        }
        #endregion
    }
    public class Col6StringComparer : IComparer<string>
    {
        #region Implementation of IComparer<in string>
        public int Compare(string x, string y)
        {
            //Rules that determine order of col 6
        }
        #endregion
    }
    public class Col2StringComparer : IComparer<string>
    {
        #region Implementation of IComparer<in string>
        public int Compare(string x, string y)
        {
            //Rules that determine order of col 2
        }
        #endregion
    }
