    private void btnPlaceOrder_Click(object sender, EventArgs e)
    {
      /* ... */
      this.Orders.Add(new DrinkOrder
      {
        Size = this.SizeControl.Value,
        Flavor = this.FlavorControl.Value,
        Toppings = this.ToppingControl.value
        Quantity = this.QuantityControl.Value
      });
      /* ... */
    }
