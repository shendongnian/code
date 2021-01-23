    .CellAction(cell =>
        {
            if (cell.Column.Title == "Commands")
            {
                if (cell.DataItem.StatusId > 0) //check whether to hide the cell
                {
                    cell.HtmlAttributes["style"] = "visibility:hidden";
                }
            }
        
        })
