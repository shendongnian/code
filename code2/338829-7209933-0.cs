    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.OleDb;
    using System.IO;
    using System.Linq;
    using System.Text;
    
    namespace XlsTests
    {
        class Program
        {
            static void Main(string[] args)
            {
                string _XlsConnectionStringFormat = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=\"Excel 12.0 Xml;HDR=NO;IMEX=1\"";
                string xlsFilename = @"C:\test.xlsx";
                using (OleDbConnection conn = new OleDbConnection(string.Format(_XlsConnectionStringFormat, xlsFilename)))
                {
                    try
                    {
                        conn.Open();
    
                        string outputFilenameHeade = Path.GetFileNameWithoutExtension(xlsFilename);
                        string dir = Path.GetDirectoryName(xlsFilename);
                        string[] sheetNames = conn.GetSchema("Tables")
                                                  .AsEnumerable()
                                                  .Select(a => a["TABLE_NAME"].ToString())
                                                  .ToArray();
                        foreach (string sheetName in sheetNames)
                        {
                            string outputFilename = Path.Combine(dir, string.Format("{0}_{1}.csv", outputFilenameHeade, sheetName));
                            using (StreamWriter sw = new StreamWriter(File.Create(outputFilename), Encoding.Unicode))
                            {
                                using (DataSet ds = new DataSet())
                                {
                                    using (OleDbDataAdapter adapter = new OleDbDataAdapter(string.Format("SELECT * FROM [{0}]", sheetName), conn))
                                    {
                                        adapter.Fill(ds);
    
                                        foreach (DataRow dr in ds.Tables[0].Rows)
                                        {
                                            string[] cells = dr.ItemArray.Select(a => a.ToString()).ToArray();
                                            sw.WriteLine("\"{0}\"", string.Join("\"\t\"", cells));
                                        }
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception exp)
                    {
                        // handle exception
                    }
                    finally
                    {
                        if (conn.State != ConnectionState.Open)
                        {
                            try
                            {
                                conn.Close();
                            }
                            catch (Exception ex)
                            {
                                // handle exception
                            }
                        }
                    }
                }
            }
        }
    }
