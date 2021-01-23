    string validPath = string.Empty;
    if (Uri.TryCreate(this.textBoxAcctPath.Text, UriKind.Absolute, out uri))
    {
       validPath = uri.AbsolutePath;               
    }
    else
    {
       throw new ArgumentException("Invalid Path");
    }
    string strSqlAcctSelect = String.Format("SELECT Code AS dhAccountType,
                                                         Name as dhAcctName 
                                               INTO {0} " + "FROM OPENROWSET('Microsoft.Ace.OLEDB.12.0', 'Excel 8.0; DATABASE = 
        {1}', 'SELECT * FROM " + "[Sheet1$]')", strAcctTabName, validPath);
