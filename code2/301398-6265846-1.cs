    @model Cart
    ...
    @using(Html.BeginForm())
    {
      @{ int index = 0; }
      @foreach(var l in Model.Lines)
      {
        @Html.Hidden("cart.Lines.Index", index);
        @Html.Hidden("cart.Lines[" + index + "].Product.ProductID", l.Product.ProductID)
        @Html.TextBox("cart.Lines[" + index + "].Quantity")
        @{ index++; }
      }
      <input type="submit" value="Update Quantity" />
    }
