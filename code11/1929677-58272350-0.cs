    public class Item
    {
        public string serial;
        public int? amount;
        public int? newAmount;
        public string status;
    }
    public class L1Item : Item
    {       
        public L1Item(string s, int a)
        {
            serial = s;
            amount = a;
            status = "deleted";
        }
    }
    public class L2Item : Item
    {
        public L2Item(string s, int a)
        {
            serial = s;
            amount = a;
            status = "new";
        }
    }
