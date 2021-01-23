        .CellAction(cell =>
    {
        if (cell.Column.Title == "Title Name")
        {
            if (!string.IsNullOrEmpty(cell.DataItem.C1D) && DateTime.ParseExact(cell.DataItem.C1D, "yyyy/mm/dd", null) > DateTime.Today.AddDays(183))
            {
                //Set the background of this cell only
                cell.HtmlAttributes["style"] = "background:red;";
            }
        }
    })
