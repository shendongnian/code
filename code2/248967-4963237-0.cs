    // Create the DataGrid and perform the databinding
    var myDataGrid = new System.Web.UI.WebControls.DataGrid();
    myDataGrid.HeaderStyle.Font.Bold = true;
    myDataGrid.DataSource = myDataTable;
    myDataGrid.DataBind();
    
    string myFile = "put the name here with full path.xls"
    var myFileStream = new FileStream( myFile, FileMode.Create, FileAccess.ReadWrite );
    
    // Render the DataGrid control to a file
    using ( var myStreamWriter = new StreamWriter( myFileStream ) )
    {
        using (var myHtmlTextWriter = new System.Web.UI.HtmlTextWriter(myStreamWriter ))
        {
            myDataGrid .RenderControl( myHtmlTextWriter );
        }
    }
