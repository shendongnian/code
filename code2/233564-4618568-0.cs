    class OrdersDetailCollection : List<OrdersDetail>
    {
        List<OrdersDetail> _List;
        public OrdersDetailCollection(IEnumerable<OrdersDetail> input)
    {
        this.AddRange(input);
        _List = this;
        _List = (from l in _List
                 orderby l.Item, l.DateExp
                 select l).ToList();
        this.Clear();
        this.AddRange(_List);
    }
    public void CalculateQty()
    {
        RemoveDuplicate();
        _List = (from l in _List
                 where double.Parse(l.QteBO) > 0
                 orderby l.DateExp, l.Item
                 select l).ToList();
        this.Clear();
        this.AddRange(_List);
    }
