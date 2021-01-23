    Regex numeric = new Regex(@"^\d+$");
    
    void GridView_RowDataBound(Object sender, GridViewRowEventArgs e) {
        // check out all cells in the current row
        foreach(var cell in e.Row.Cells) {
            // do some validation thingy
            if(!numeric.Match(cell.Text).Success) {
                 cell.CssClass = "error"; // put error class on the cell
            }
        }
    }
