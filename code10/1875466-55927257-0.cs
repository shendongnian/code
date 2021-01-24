    using System.Data;
    using System.Data.SqlClient;
    using System.Net.Mail;
    
    namespace ConsoleApp10
    {
        class Program
        {
            static void Main(string[] args)
            {
                var mm = new MailMessage();
                using (var conn = new SqlConnection("your connection string"))
                {
                    using (var comm = new SqlCommand())
                    {
    
                        comm.Connection = conn;
                        conn.Open();
    
    
                        comm.CommandText =
                            @"INSERT INTO [EMail].[MailAttachments] (fileName,fileSize,attachment)
                                                 SELECT fileName, fileSize, attachment FROM @tvpEmails";
    
    
                        var dt = CreateTable();
                        foreach (var eml in mm.Attachments)
                        {
                            var newRow = dt.NewRow();
                            newRow["FileName"] = eml.Name;
                            newRow["FileSize"] = eml.ContentStream.Length;
                            var allBytes = new byte[eml.ContentStream.Length];
                            newRow["Attachment"] = allBytes;
                            eml.ContentStream.Position = 0;
                            dt.Rows.Add(newRow);
                        }
    
                        comm.Parameters.AddWithValue("@tvpEmails", dt);
                        comm.Parameters[comm.Parameters.Count - 1].TypeName = "EMAIL.TVP_Emails";
                        comm.Parameters[comm.Parameters.Count - 1].SqlDbType = SqlDbType.Structured;
                        comm.ExecuteNonQuery();
                        if (conn.State == ConnectionState.Open)
                            conn.Close();
                    }
    
                }
    
            }
            private static DataTable CreateTable()
            {
                var dt = new DataTable();
                dt.Columns.Add("FileName", typeof(string));
                dt.Columns.Add("FileSize", typeof(long));
                dt.Columns.Add("Attachment", typeof(byte[]));
                return dt;
            }
    
        }
    }
