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
            if (!int.TryParse(x, out xInt))
            {
                result = 1;
            }
            if (!int.TryParse(y, out yInt) && result != 1)
            {
                result = -1;
            }
            else if (result == 0)
            {
                result = xInt - yInt;
            }
            else
            {
                result = string.Compare(x, y, true);
            }
            return result;
        }
    }
