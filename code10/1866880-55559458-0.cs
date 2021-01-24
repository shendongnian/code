    public IEnumerable<SelectListItem> ShippingQuotes
    {
         get { return ShippingQuotes.Select(x => {x.Text = "Some Text" + x.Text; return x;}); } 
         set { ShippingQuotes = value; }
    }
