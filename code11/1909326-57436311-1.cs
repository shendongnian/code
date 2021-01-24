    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.IO;
    using System.Data.SqlClient;
    using System.Data.OleDb;
    using System.Configuration;
    
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
    
                string server = "EXCEL-PC\\EXCELDEVELOPER";
                string database = "AdventureWorksLT2012";
                string SQLServerConnectionString = String.Format("Data Source={0};Initial Catalog={1};Integrated Security=SSPI", server, database);
    
    
                string CSVpath = @"C:\Users\Ryan\Documents\Visual Studio 2010\Projects\Bulk Copy from CSV to SQL Server Table\WindowsFormsApplication1\bin"; // CSV file Path
                string CSVFileConnectionString = String.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};;Extended Properties=\"text;HDR=Yes;FMT=Delimited\";", CSVpath);
    
                var AllFiles = new DirectoryInfo(CSVpath).GetFiles("*.CSV");
                string File_Name = string.Empty;
    
                foreach (var file in AllFiles)
                {
                    try
                    {
                        DataTable dt = new DataTable();
                        using (OleDbConnection con = new OleDbConnection(CSVFileConnectionString))
                        {
                            con.Open();
                            var csvQuery = string.Format("select * from [{0}]", file.Name);
                            using (OleDbDataAdapter da = new OleDbDataAdapter(csvQuery, con))
                            {
                                da.Fill(dt);
                            }
                        }
    
                        using (SqlBulkCopy bulkCopy = new SqlBulkCopy(SQLServerConnectionString))
                        {
                            bulkCopy.ColumnMappings.Add(0, "MyGroup");
                            bulkCopy.ColumnMappings.Add(1, "ID");
                            bulkCopy.ColumnMappings.Add(2, "Name");
                            bulkCopy.ColumnMappings.Add(3, "Address");
                            bulkCopy.ColumnMappings.Add(4, "Country");
                            bulkCopy.DestinationTableName = "AllEmployees";
                            bulkCopy.BatchSize = 0;
                            bulkCopy.WriteToServer(dt);
                            bulkCopy.Close();
                        }
    
                    }
                    catch(Exception ex)
                         {
                             MessageBox.Show(ex.Message, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                         }
                }
            }
        }
    }
