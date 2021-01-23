    if (Role != "admin")
        return;
    var dataTable = new DataTable();
    var stringBuilder = new StringBuilder();
    using (var connection = new SqlConnection("Server=ILLUMINATI;" + "Database=DB;Integrated Security= true"))
    using (var command = connection.CreateCommand())
    {
        connection.Open();
        command.CommandText = "Select * from FileUpload where UploadedBy = @UploadedBy AND FilePath = @FilePath";
        command.Parameters.AddWithValue("UploadedBy", NAME);
        var filPathParameter = command.Parameters.Add("FilePath", SqlDbType.VarChar);
        for (int j = 0; j < i; j++)
        {
            stringBuilder.Append(fipath[j]);
            stringBuilder.Append("-------------");
            filPathParameter.Value = fipath[j];
            dataTable.Load(command.ExecuteReader(), LoadOption.PreserveChanges);
        }
    }
    Label1.Text += stringBuilder.ToString();
    GridView1.DataSource = dataTable;
    GridView1.DataBind();
