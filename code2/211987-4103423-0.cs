    using System;
    using System.IO;
    using System.Data;
    using System.Data.SqlClient;
    using System.Data.SqlTypes;
    using Microsoft.SqlServer.Server;
    using System.Security.Permissions;
    namespace ExtractSqlAssembly {
        [PermissionSet(SecurityAction.Demand, Unrestricted = true, Name = "FullTrust")]
        public partial class SaveSqlAssembly {
            [SqlProcedure]
            public static void SaveAssembly(string assemblyName, string path) {
                string sql = @"SELECT AF.content FROM sys.assembly_files AF JOIN sys.assemblies A ON AF.assembly_id = A.assembly_id where AF.file_id = 1 AND A.name = @assemblyname";
                using (SqlConnection conn = new SqlConnection("context connection=true")) {
                    using (SqlCommand cmd = new SqlCommand(sql, conn)) {
                        SqlParameter param = new SqlParameter("@assemblyname", SqlDbType.VarChar);
                        param.Value = assemblyName;
                        cmd.Parameters.Add(param);
                        cmd.Connection.Open();  // Read in the assembly byte stream
                        SqlDataReader reader = cmd.ExecuteReader();
                        reader.Read();
                        SqlBytes bytes = reader.GetSqlBytes(0);
                        // write the byte stream out to disk
                        FileStream bytestream = new FileStream(path, FileMode.CreateNew);
                        bytestream.Write(bytes.Value, 0, (int)bytes.Length);
                        bytestream.Close();
                    }
                }
            }
        }
    }
