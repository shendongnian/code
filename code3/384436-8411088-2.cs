    GridView1_RowCreated(Object sender, GridViewRowEventArgs e)
    {
       //some code here
    
       LinkButton lb = new LinkButton();
       lb.Text = "something";
       lb.ID = "someId";
       
       TableCell cell = new TableCell();
       cell.Controls.Add(lb);
       e.Row.Cells.Add(cell);
    }
