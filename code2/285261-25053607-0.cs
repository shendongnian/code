    using (SqlConnection cnn = new SqlConnection(mConnStr)) {
    DataSet Data = new DataSet();
    cnn.Open();
    string sql = "SELECT * FROM Person";
    using (SqlDataAdapter Da = new SqlDataAdapter(sql, cnn))
    {
    try
    {
        Da.Fill(Data);
        Data.WriteXmlSchema(@"C:\Person.xsd");
    }
    catch (Exception ex)
    { MessageBox.Show(ex.Message); }
    }
    cnn.Close();
