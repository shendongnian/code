    @if(Order.OrderItems[i] != null)
    {
        <input asp-for="Order.OrderItems[i].OrderItemId" />
        <input asp-for="Order.OrderItems[i].Item" />
        <input asp-for="Order.OrderItems[i].Price">
    }
    else
    {
        // new form to post the 3 inputs, allowing to reload the page with the new non null values ...
    }
