    if (tvwACH.SelectedNode.Parent != null)
    {
            int id  = tvwACH.SelectedNode.Tag as int; // make sure you've already assigned tag when creating Three nodes and data rows
            foreach(Row row in this.dataGridView1.Rows)
            {
               int rowId = row.Tag as int;
                if(rowId == id)
                {
                  row.Selected = ture;
                }
                else
                {
                  row.Selected = false; //discard other rows 
                }
             }
    }
