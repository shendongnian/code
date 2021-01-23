    WebGridColumn adminColumn = grid.Column(columnName: string.Empty,
      header: string.Empty,
      format: (item) => new HtmlString(Html.ActionLink("Edit", "Edit",
        new { id = item.Id }, null).ToString() + "|" +
        Html.ActionLink("Delete", "Delete", new { id = item.Id }, null).ToString()));
    columns.Add(adminColumn);
