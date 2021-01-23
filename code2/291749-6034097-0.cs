    I used something once. It is not the best practice but it worked for me.
    BTW I used it an Edit Button not in an Edit Text but i think it has to work as the same way.
    
     In the RowDataBound Event of the GridView use this:
    
     if (e.Row.RowType == DataControlRowType.DataRow)
     {
            //Use the index of your Edit Cell
            if(bool.Parse(DataBinder.Eval(e.Row.DataItem, "Status"))
            {
                e.Row.Cells[8].Controls.Clear();
            }
         
     }
