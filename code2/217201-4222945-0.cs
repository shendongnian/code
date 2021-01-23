        //Consider the below dataset holds data
         DataSet dsItemsFind = new DataSet();
        //Use Looping to browse through the Treeview and DataTable
        for (int i = 0; i < Treeview1.Nodes.Count; i++)
        {
            for (int j = 0; j < dsItemsFind.Tables[0].Rows.Count; j++)
            {
                if (Treeview1.Nodes[i].Value.ToString() == dsItemsFind.Tables[0].Rows[j]["ColumnName"].ToString())
                {
                    //If ur Treeview Node value is = the Column value your looking for
                    //Then the Below line will get called
                    Treeview1.Nodes[i].Checked=true;                   
                }
            }
        }
