    @(Html.Telerik().Grid(Model)
        .Name("myGrid")
        .Columns(columns =>
        {
            columns.Bound(o => o.OrderID).Width(100);
            columns.Bound(o => o.ContactName).Width(200);
            columns.Bound(o => o.ShipAddress);
            columns.Bound(o => o.OrderDate).Format("{0:MM/dd/yyyy}").Width(120);
        }).ClientEvents(events => events.OnDataBound("GridOnDataBound"))
    ......
    ......
    ).HtmlAttributes(new {style = "display: none"})
