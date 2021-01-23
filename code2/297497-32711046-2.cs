    @grid.GetHtml(
        columns: grid.Columns(
            grid.Column(header: "Serial No", format:@<text><div>@(item.WebGrid.Rows.IndexOf(item) + 1)</div></text>),
            grid.Column(columnName: "Stdname", header: "Student Name"),
            grid.Column(header: "Email ID", format:@<text><a href="mailto:@item.Email">@item.Email</a></text>),
            grid.Column(header: "EDIT",format: (item) => Html.ActionLink("Edit", "Edit", new { id = item.ID })),
            grid.Column(header: "DETAILS", format: (item) => Html.ActionLink("Details", "Details", new { id = item.ID })),
            grid.Column(header: "DELETE", format: (item) => Html.ActionLink("Delete", "Delete", new { id = item.ID }))
    ))
