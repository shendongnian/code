    System.Web.UI.WebControls.GridView() test = new System.Web.UI.WebControls.GridView();
    for (int i = 0; i < test.RowCount; i++)
    {
        test["<yer column name>", i].Value = "=\"" 
            + test["<yer column name>", i].Value + "\"";
    }
