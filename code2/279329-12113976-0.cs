    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Data;
    using System.Data.SqlClient;
    using System.IO;
     
    namespace DoxoEater2
    {
        class Program
        {
            static void Main(string[] args)
            {
     
                // WSS 3.0 default DB via SQL 2005 embedded edition.
                //string DBConnString = "Data Source=\\\\.\\pipe\\MSSQL$MICROSOFT##SSEE\\sql\\query;Database=WSS_Content;Trusted_Connection=yes;Timeout=2000;MultipleActiveResultSets=True";
                
                // Or localhost, WSS_Content, typical SQL connection style, TCP/IP listener.
                string DBConnString = "Data Source=localhost;Database=WSS_Content;Trusted_Connection=yes;Timeout=2000;MultipleActiveResultSets=True";
                string DocsQuery = "select [AllDocs].[Id], [AllDocs].[DirName], [AllDocs].[LeafName] from [AllDocs] where dirname <> '' order by dirname;";
     
                Console.WriteLine("START: " + DateTime.Now.ToUniversalTime() + " UTC");
     
                SqlConnection con;
     
                try // create a DB connection
                {   
                    con = new SqlConnection(DBConnString);
                    con.Open();
                }
                catch (Exception e) {
                    Console.WriteLine(e.Message);
                    return;
                }
     
                SqlCommand com = con.CreateCommand();
                com.CommandText = DocsQuery;
     
                // readers for SQL queries: 1) which docs? 2) featch binary data per DocID
                SqlDataReader reader, reader2;
     
                try {   // execute query
                    reader = com.ExecuteReader();
                }
                catch (Exception e) {
                    if (con != null) { con.Close(); }
                    Console.WriteLine(e.Message); 
                    return;
                }
     
                while (reader.Read()) { // rows of document ID, name and directory nodes
     
                    // grab the file's directory and name
                    Guid FileId = (Guid)reader["Id"];
                    string DirName = (string)reader["DirName"];
                    string LeafName = (string)reader["LeafName"];
               
                    // create directory for the file if it doesn't yet exist
                    if (!Directory.Exists(DirName))
                    {
                        Directory.CreateDirectory(DirName);
                        Console.WriteLine("DIR: " + DirName);
                    }
     
                    // check if file already exists or not
                    if (File.Exists(DirName + "/" + LeafName)) {
                        Console.WriteLine("ERROR: File Already Exists: " + DirName + "/" + LeafName);
                        continue;
                    }
     
                    SqlCommand com2 = con.CreateCommand();
                    com2.CommandText = "select content from [AllDocStreams]  where  [AllDocStreams].[Id] = '" + FileId.ToString() + "';";
                    Console.WriteLine("SQL: " + com2.CommandText.ToString());
     
                    try
                    {   // execute file fetch query
                        reader2 = com2.ExecuteReader(CommandBehavior.SequentialAccess);
                    }
                    catch (Exception e)
                    {
                        if (con != null) { con.Close(); }
                        Console.WriteLine(e.Message);
                        return;
                    }
     
                    while(reader2.Read()) {
                 
                        // create a filestream to spit out the file
                        FileStream fs = new FileStream(DirName + "/" + LeafName, FileMode.Create, FileAccess.Write);
                        BinaryWriter writer = new BinaryWriter(fs);
     
     
                        // depending on the speed of your network, you may want to change the buffer size (it's in bytes)
                        int bufferSize = 1048576;
                        long startIndex = 0;
                        long retval = 0;
                        byte[] outByte = new byte[bufferSize];
     
                        // grab the file out of the db one chunk (of size bufferSize) at a time
                        do
                        {
                            retval = reader2.GetBytes(0, startIndex, outByte, 0, bufferSize);
                            startIndex += bufferSize;
     
                            writer.Write(outByte, 0, (int)retval);
                            writer.Flush();
                        } while (retval == bufferSize);
     
                        // finish writing the file
                        Console.WriteLine("FILE: " + LeafName);
                        writer.Close();
                        fs.Close();
                 
                    }
                    reader2.Close();
     
                }
     
                // close the DB connection and whatnots
                reader.Close();
                con.Close();
     
                Console.WriteLine("DONE: " + DateTime.Now.ToUniversalTime() + " UTC");
            }
        }
    }
