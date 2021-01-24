    Using System.Data.SqlClient;
    Public Class DAL
    {
        Public Static void GetQueryResults(String cmdText)
        {
            SqlConnection oConn = New SqlConnection();
            oConn.ConnectionString = MainW.MyConnection;  // get connection string
            SqlCommand cmd = New SqlCommand(cmdText, oConn);
            DataSet ds = New DataSet();
            SqlDataAdapter da = New SqlDataAdapter(cmd);
            Try
            {
                oConn.Open();
                da.Fill(ds);       // retrive data
                oConn.Close();
            }
            Catch (Exception ex)
            {
                SysErrScreen errform = New SysErrScreen();
                errform.ChybaText.Text = ex.Message + Constants.vbCrLf + Constants.vbCrLf + cmdText;
                errform.ShowDialog();
                oConn.Close();
            }
            Return ds;
        }
    }
