    class Program
    {
        private static void SaveXmlToDatabase(DbConnection connection,
              XmlDocument xmlToSave)
        {
           String sql = "INSERT INTO xmlTable(xmlColumn) VALUES (@xml)";
    
           using (DbCommand command = connection.CreateCommand())
           {
              command.CommandText = sql;
              command.Parameters.Add(
                new SqlParameter("@xml", SqlDbType.Xml) 
                   {Value = new SqlXml(new XmlTextReader(xmlToSave.InnerXml
                               , XmlNodeType.Document, null)) });
    
              DbTransaction trans = connection.BeginTransaction();
              try
              {
                 command.ExecuteNonQuery();
                 trans.Commit();
              }
              catch (Exception)
              {
                 trans.Rollback();
                 throw;
              }
           }
        }
    
        static void Main(string[] args)
        {
            XmlDocument document = new XmlDocument();
            document.Load(args.First());
    
            SqlConnection connection = new SqlConnection(
                "Server=myServerAddress;Database=myDataBase;Trusted_Connection=True;");
    
            SaveXmlToDatabase(connection, document);
            
            connection.Close();
        }
    }
