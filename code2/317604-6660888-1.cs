    public class WeirdComparer : IComparer,IComparer<TestObject>
    {
        private IList<int> order;
        public WeirdComparer(IList<int> order)
        {
            this.order = order;
        }
        public int Compare(object x, object y)
        {
            return Compare((TestObject) x, (TestObject) y);
        }
    
        public int Compare(TestObject x, TestObject y)
        {
            if(order.Contains(x.Id))
            {
                if(order.Contains(y.Id))
                {
                    return order.IndexOf(x.Id).CompareTo(order.IndexOf(y.Id));    
                }
                return -1;
            }
            else
            {
                if (order.Contains(y.Id))
                {
                    return 1;
                }
                return x.Id.CompareTo(y.Id);
            }
        }
    }
