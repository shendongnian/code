    @{
        var grid = new WebGrid(canPage: true, rowsPerPage: ThisController.PageSize, canSort: true, ajaxUpdateContainerId: "grid");
        grid.Bind(Model.Employees, rowCount: Model.TotalRecords, autoSortAndPage: false);
        grid.Pager(WebGridPagerModes.All);
        @grid.GetHtml(htmlAttributes: new { id="grid" },
            columns: grid.Columns(
                grid.Column(format: (item) => Html.ActionLink("Edit", "Edit", new { EmployeeID = item.EmployeeID })),
                grid.Column("FullName"),
                grid.Column("Title")
            ));
    }
