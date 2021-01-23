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
            int result = -1;
            if (!int.TryParse(x, out xInt))
            {
                result = 1;
            }
            if (result == -1 && int.TryParse(y, out yInt))
            {
                result = xInt - yInt;
            }
            else if (!int.TryParse(y, out yInt))
            {
                result = string.Compare(x, y, true);
            }
            return result;
        }
    }
