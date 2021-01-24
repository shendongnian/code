c#
private void foo(string matchText, string sortBy) {
    if (comboBox1.Text == matchText)
    {
        string dgvconn = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\n0740572\Projects\CW\CW\bin\Debug\Database1.mdf;Integrated Security=True";
        string sql = "select * from Records where UserID = @userID Order By " + sortBy;
        SqlConnection connection = new SqlConnection(dgvconn);
        SqlDataAdapter dataadapter = new SqlDataAdapter(sql, connection);
        dataadapter.SelectCommand.Parameters.AddWithValue("@userID", currentUserID);
        DataSet ds = new DataSet();
        connection.Open();
        dataadapter.Fill(ds, "Records");
        connection.Close();
        recordsDataGridView.DataSource = ds;
        recordsDataGridView.DataMember = "Records";
    }     
}//foo
//Call the method
foo("Most recent first", "Date DESC");
foo("Most recent last", "Date");
foo("By Username", "User");
