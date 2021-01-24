public Class Order {
    public int OrderID { get; set; }
    public string Name { get; set; }
    public byte Quality { get; set; }
    public string Description { get; set; }
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
   BindingList<Order> myBindingList = New BindingList<Order>(myOrder);
   dgvOrder.DataSource = myBindingList;
}
EDIT: I missed that BindingList does not implement IContainer, the below code will not work. Leaving it so others who read OPs comment will understand what was being referenced.
I would also recommend wrapping the BindingList in a BindingSource, which will prevent you from having to handle rows being added/deleted manually:
if (myOrder != null) {
   BindingList<Order> myBindingList = New BindingList<Order>(myOrder);
   BindingSource myBindingSource = New BindingSource(myBindingList);
   dgvOrder.DataSource = myBindingSource;
}
Apologies if my syntax is a little off, I've been mostly using vb as of late.
