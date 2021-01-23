    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
     {
           //Or you can use e.Row.Cells[0].FindControl("ur control id");
           foreach (object  c in e.Row.Cells[0].Controls)
           {
               ImageButton btn = c as ImageButton;
               if (c != null && role == "something")
               {
                   //Do your logic here
               }
           }
      }
