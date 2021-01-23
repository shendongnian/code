    .CellAction(cell =>
        {
            if (cell.Column.Title == "Commands")
            {
                if (cell.DataItem.Discontinued)
                {
                    cell.HtmlAttributes["style"] = "visibility:hidden";
                }
            }
        
        })
