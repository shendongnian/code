public Class Order {
    public int OrderID { get; set; }
    public String Name { get; set; }
    public Byte Quality { get; set; }
    public String Description { get; set; }
}
Then in your query,
select new Order
{
    OrderId = m.MedId,
    Name = m. Name,
    Quality = m.Quality,
    Description = d.Description
}
Now move it to a BindingList<Order>:
if (myOrder != null) {
   BindingList<Order> myBindingList = New BindingList<Order>(MyOrder);
   dgvOrder.DataSource = myBindingList;
}
I would also recommend wrapping the BindingList in a BindingSource, which will prevent you from having to handle rows being added/deleted manually:
if (myOrder != null) {
   BindingList<Order> myBindingList = New BindingList<Order>(MyOrder);
   BindingSource myBindingSource = New BindingSource(myBindingList);
   dgvOrder.DataSource = myBindingSource;
}
Apologies if my syntax is a little off, I've been mostly using vb as of late.
