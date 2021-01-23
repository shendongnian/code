    Dim sb As OleDbConnectionStringBuilder = New System.Data.OleDb.OleDbConnectionStringBuilder()
    sb.Provider = "Microsoft.ACE.OLEDB.12.0"
    sb.DataSource = "c:\datafile.accdb"
    sb.OleDbServices = -1
    Using connection As New OleDbConnection(sb.ToString())
    ....
    End Using
