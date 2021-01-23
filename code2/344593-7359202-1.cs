    public struct MyValue
    {
        public List<int> lst;
        public List<DateTime> lstdt;
    }
    public class MyDictionary : Dictionary<int, MyValue>
    {
        public void Add(int key, List<int> lst1, List<DateTime> lstDt1)
        {
            MyValue v1 = new MyValue();
            v1.lst = lst1;
            v1.lstdt = lstDt1;
            this.Add(key, v1);
        }
    }
