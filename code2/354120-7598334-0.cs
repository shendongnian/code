    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
     {
           foreach (object  c in e.Row.Controls)
           {
               ImageButton btn = c as ImageButton;
               if (c != null && role == "something")
               {
                   //Do your logic here
               }
           }
      }
