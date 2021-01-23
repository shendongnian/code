    int x = 0;
    
    for (int i = 0; i < Product.Items.Count; ++i)
    {
         if (table.Rows[i]["id"].ToString() == "3")
         {
           x++;
         }
    }
    
    lblCounter.Text = x.ToString();
