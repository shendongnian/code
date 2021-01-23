    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    using System.Data.OleDb;
    using System.IO;
    
    namespace Immo.Areas.Administration.Controllers
    {
        public class SomethingSometingExcelClass
        {
            public void DoSomethingWithExcel(string filePath)
            {
    
                GeoDataProvider provider = new Google(db);            
                List<DataTable> worksheets = ImportExcel(filePath);
                foreach(var item in worksheets){
                    foreach (DataRow row in  item.Rows)
                    {
                       //add to array
                    }
    
                }
            }
            /// <summary>
            /// Imports Data from Microsoft Excel File.
            /// </summary>
            /// <param name="FileName">Filename from which data need to import</param>
            /// <returns>List of DataTables, based on the number of sheets</returns>
            private List<DataTable> ImportExcel(string FileName)
            {
                List<DataTable> _dataTables = new List<DataTable>();
                string _ConnectionString = string.Empty;
                string _Extension = Path.GetExtension(FileName);
                //Checking for the extentions, if XLS connect using Jet OleDB
                if (_Extension.Equals(".xls", StringComparison.CurrentCultureIgnoreCase))
                {
                    _ConnectionString =
                        "Provider=Microsoft.Jet.OLEDB.4.0; Data Source={0};Extended Properties=Excel 8.0";
                }
                //Use ACE OleDb
                else if (_Extension.Equals(".xlsx", StringComparison.CurrentCultureIgnoreCase))
                {
                    _ConnectionString =
                        "Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=Excel 8.0";
                }
    
                DataTable dataTable = null;
    
                using (OleDbConnection oleDbConnection =
                    new OleDbConnection(string.Format(_ConnectionString, FileName)))
                {
                    oleDbConnection.Open();
                    //Getting the meta data information.
                    //This DataTable will return the details of Sheets in the Excel File.
                    DataTable dbSchema = oleDbConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables_Info, null);
                    foreach (DataRow item in dbSchema.Rows)
                    {
                        //reading data from excel to Data Table
                        using (OleDbCommand oleDbCommand = new OleDbCommand())
                        {
                            oleDbCommand.Connection = oleDbConnection;
                            oleDbCommand.CommandText = string.Format("SELECT * FROM [{0}]",
                                item["TABLE_NAME"].ToString());
                            using (OleDbDataAdapter oleDbDataAdapter = new OleDbDataAdapter())
                            {
                                oleDbDataAdapter.SelectCommand = oleDbCommand;
                                dataTable = new DataTable(item["TABLE_NAME"].ToString());
                                oleDbDataAdapter.Fill(dataTable);
                                _dataTables.Add(dataTable);
                            }
                        }
                    }
                }
                return _dataTables;
            }
        }
    }
