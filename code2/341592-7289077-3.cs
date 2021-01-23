    @model IEnumerable<Foo>
    @{
        var grid = new WebGrid(Model, defaultSort: "sortMe", rowsPerPage: 10);
        grid.GetHtml(htmlAttributes: new { id = "DataTable" });
    }
    @grid.GetHtml(
    columns: grid.Columns(
        grid.Column(
            columnName: "Name",
            header: "Foo"
        ),
        grid.Column(
            columnName: "Lookup.Name",
            header: "Lookup",
            format: @<span>@if (item.Lookup != null)
                           { @item.Lookup.Name }
            </span>
        ),
        grid.Column(
            columnName: "Lookup.Description.English",
            header: "Description.English",
            format: @<span>@if (item.Lookup != null && item.Lookup.Description != null)
                           { @item.Lookup.Description.English }
            </span>
        ),
        grid.Column(
            columnName: "Lookup.Description.French",
            header: "Description.French",
            format: @<span>@if (item.Lookup != null && item.Lookup.Description != null)
                           { @item.Lookup.Description.French }
            </span>
        )
    )
    )
