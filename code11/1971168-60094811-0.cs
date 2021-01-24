DataTable issueView = new DataTable();
SqlConnection issueConn = new SqlConnection(GetConnectionString());
issueConn.Open();
SqlCommand issueCmd = new SqlCommand("sp_Populate_Issue_View", issueConn)
{
    CommandType = CommandType.StoredProcedure
};
if (chkHideReturned.Checked == true)
{
    issueCmd.Parameters.AddWithValue("Codefrom", 100);
    issueCmd.Parameters.AddWithValue("Codeto", 100);
}
else
{
    issueCmd.Parameters.AddWithValue("Codefrom", 100);
    issueCmd.Parameters.AddWithValue("Codeto", 120);
}
SqlDataAdapter da2 = new SqlDataAdapter(issueCmd);
da2.Fill(issueView);
dataGridView2.DataSource = issueView;
