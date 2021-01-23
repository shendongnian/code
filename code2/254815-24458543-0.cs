        grid.RowDataBound += (s, e) =>
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var test = DataBinder.Eval(e.Row.DataItem, "Id");
            }
        }
