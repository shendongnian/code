     GridViewRow gRow = (GridViewRow)(sender as Control).Parent.Parent;
     string trying_to_get = string.Empty;
     if (gRow != null) 
     {
        trying_to_get = gRow.Cells[0].Text;
     }
