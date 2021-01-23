    public readonly IProp<Customer> TheCustomer;
    public readonly IProp<double> TotalPrice;
    protected override void OnPropChanged(PropChangedEventArgs args)
    {
        if (args.Prop.IsAny(TheCustomer, Item.Schema.Price))
        {
            TotalPrice.Value = TheCustomer.Value.Orders
                .Sum(order => order.Items.Sum(item => item.Price.Value));
        }
    }
