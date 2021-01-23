      var listIds=new List<int>();
        for (int i = 0; i < grid1.RowCount - 1; i++)
        {
            if (grid1.Rows[i].Cells["SelectCol"].Value != null)
              {
                bool value = Convert.ToBoolean(grid1.Rows[i].Cells["SelectCol"].Value);
                if(value)
                     listId.Add(Convert.ToInt32(grid1.Rows[i].Cells["SiteID"].Value));
               }
        }
