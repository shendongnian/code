    @model RouteValueDictionary
    
    <h2>Company Details</h2>
    @foreach (var item in Model)
    {
        if (IsVisible(item.Key))
        {
            <div>@item.Value</div>
        }
    }
