    public class Test
    {
        public void TestMethod()
        {
            List<string> buyersList = new List<string>() { "5", "10", "1", "str", "3", "string" };
            List<string> soretedBuyersList = null;
            soretedBuyersList = new List<string>(SortedList(buyersList));
        }
        public List<string> SortedList(List<string> unsoredList)
        {
            return unsoredList.OrderBy(o => o, new SortNumericComparer()).ToList();
        }
    }
    public class SortNumericComparer : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            int xInt = 0;
            int yInt = 0;
            int result = 0;
            bool isXNumaric = false;
            bool isYNumaric = false;
            if (int.TryParse(x, out xInt))
            {
                isXNumaric = true;
            }
            if (int.TryParse(y, out yInt))
            {
                isYNumaric = true;
            }
            if (isXNumaric && isYNumaric)
            {
                if (xInt > yInt)
                {
                    result = 1;
                }
                else if (xInt < yInt)
                {
                    result = -1;
                }
                else
                {
                    result = 0;
                }
            }
            else if (isXNumaric)
            {
                result = -1;
            }
            else if (isYNumaric)
            {
                result = 1;
            }
            else
            {
                result = string.Compare(x, y, true);
            }
            return result;
        }
    }
