    @(Html.Grid(Model)
        .Columns(column =>
        {
            column.For(x => Html.ActionQueryLink(x.Name, "Edit", new { id = x.Id })).Named("Name");
            column.For(x => x.Number).Named("Number");
        })
        .Attributes(@class => "grid-style")
        .Empty("No data."))
