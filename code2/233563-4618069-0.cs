    public class OrderDetailCollection
    {
        private List<OrdersDetail> _List;
        public OrdersDetailCollection(IEnumerable<OrdersDetail> input)
        {
            this._List = input.OrderBy(xx => xx.Item)
                              .ThenBy(xx => xx.DateExp)
                              .ToList();
           RemoveDuplicates();
        }
        public IEnumerable<OrdersDetail> CalculateQuantity()
        {
             return from xx in this._List
                   where double.Parse(xx.QteBO) > 0.0
                   orderby xx.DateExp, xx.Item
                   select xx;
        }
    }
