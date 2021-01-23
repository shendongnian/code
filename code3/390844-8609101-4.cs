    @model IEnumerable<MvcApp.Models.Product>
    
    @{
        Layout = "~/Views/Shared/_Layout.cshtml";
        ViewBag.Title = "List of Products";
    }
    
    <h2>Product List</h2>
    <ul>
        @foreach (var p in Model)
        {
            <li>@p.Name></li>
            <li>@p.Description</li>
            <li>@p.Price</li>
        }
    </ul>
