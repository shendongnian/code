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
I would also recommend wrapping the BindingList in a BindingSource, which will prevent you from having to handle rows being added/deleted manually:
if (myOrder != null) {
   BindingList<Order> myBindingList = New BindingList<Order>(myOrder);
   BindingSource myBindingSource = New BindingSource(myBindingList);
   dgvOrder.DataSource = myBindingSource;
}
Apologies if my syntax is a little off, I've been mostly using vb as of late.
**EDIT: I missed that BindingList does not implement IContainer, so the above code for binding to a BindingSource will not work because the single-parameter constructor for BindingSource specifically takes an IContainer.** If you still want to use a BindingSource, the third constructor of BindingSource should be used instead, like so:
BindingSource myBindingSource = New BindingSource(myBindingList, Nothing);
BindingSource does accept binding to an IBindingList, but only using this constructor or by directly setting the .DataSource property after using the parameterless constructor.
Leaving the erroneous code above so others who read OP's comment will understand what was being referenced.
