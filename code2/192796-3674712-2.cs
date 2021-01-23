    if (tvwACH.SelectedNode.Parent != null)
    {
            int id  = (int)tvwACH.SelectedNode.Tag ; // make sure you've already assigned tag when creating Three nodes and data rows
            foreach(DataGridViewRow  row in this.dataGridView1.Rows)
            {
               int rowId = (int)row.Tag ;
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
