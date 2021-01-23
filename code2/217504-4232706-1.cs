    public string ReadXmlData(int ID)
    {
       string query = "SELECT XmlContent FROM dbo.xmlTB WHERE ID = @ID";
       string connectionString = "Data Source=SERVER1\\SQLEXPRESS;Initial Catalog=xml;Integrated Security=True;Pooling=False";
       using(SqlConnection conn = new SqlConnection(connectionString))
       using(SqlCommand cmd = new SqlCommand(query, conn))
       {
          cmd.Parameters.Add("@ID", SqlDbType.Int);
          cmd.Parameters["@ID"].Value = ID;
 
          conn.Open();
          string xmlContents = cmd.ExecuteScalar().ToString();
          conn.Close();
          return xmlContents;
       }
       catch (Exception)
       {
           return flag;
       }
    }
