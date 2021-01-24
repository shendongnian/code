foreach (var item in fileNameList)
{
    if (fileinfoList.Select(m => m.partNumber == dummyString.ToString()) != null)
    {
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = @"data source = MYPC\SQLEXPRESS; database = MYDB; integrated security = TRUE";
        string query = $@"SELECT id, fullpath FROM MYTABLE WHERE fullpath= '{pathsToFilesNotOnDbList[y]}' ";
        var cmd = new SqlCommand(query, conn);
        conn.Open();
        SqlDataReader dataReader = cmd.ExecuteReader();
        while (dataReader.Read())
        {
            iD = Convert.ToInt16(dataReader["id"]);
            fileinfoList.FirstOrDefault(f => f.fullpath == dataReader["fullPath"]).baseID = iD;
            Console.WriteLine(y);
            y++;
        }
        conn.Close();
    }
}
