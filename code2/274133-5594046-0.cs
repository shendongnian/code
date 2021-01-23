    DataTable dtbl1=new DataTable();//parent datatable
    DataTable dtbl2=new DataTable();//child datatable
    DataSet ds = new DataSet();
    ds.Tables.Add(dtbl1);
    ds.Tables.Add(dtbl2);
    ds.Relations.Add("Children", dtbl1.Columns["dtb1ID"], dtbl2.Columns["dtbl2ID"]);//define parent child relation in dataset
    if (ds.Tables[0].Rows.Count > 0)
    {
        trv.Nodes.Clear();
        Int32 count = 0;
        foreach(DataRow masterRow in  ds.Tables[0].Rows)
        {
            TreeNode masterNode = new TreeNode((String)masterRow["dtbl1ColumnYouWantToDisplay"], Convert.ToString(masterRow["dtbl1ID"]));
            trv.Nodes.Add(masterNode);
            foreach (DataRow childRow in masterRow.GetChildRows("Children"))
            {
                TreeNode childNode = new TreeNode((String)childRow["dtbl2ColumnYouWantToDisplay"], Convert.ToString(childRow["dtb2ID"]));
                masterNode.ChildNodes.Add(childNode);
                count++;
            }
        }
        trv.ExpandAll();
    }
