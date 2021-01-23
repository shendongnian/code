    OleDbConnectionStringBuilder builder = new OleDbConnectionStringBuilder();
    if (isOpenXML)
        builder.Provider = "Microsoft.ACE.OLEDB.12.0";
    else
        builder.Provider = "Microsoft.Jet.OLEDB.4.0";
    builder.DataSource = fileName;
    builder["Extended Properties"] = "Extended Properties=\"Excel 8.0;HDR=YES;\""
    using (var con = new OleDbConnection(builder.ToString())) {
        ...
    }
