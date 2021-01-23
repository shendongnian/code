    using System;
    using System.Data;
    using Microsoft.SqlServer.Dts.Runtime;
    using System.Windows.Forms;
    using System.Data.SqlClient;
    using System.IO;
    
    namespace ST_80294de8b8dd4779a54f707270089f8c.csproj
    {
        [System.AddIn.AddIn("ScriptMain", Version = "1.0", Publisher = "", Description = "")]
        public partial class ScriptMain : Microsoft.SqlServer.Dts.Tasks.ScriptTask.VSTARTScriptObjectModelBase
        {
    
            #region VSTA generated code
            enum ScriptResults
            {
                Success = Microsoft.SqlServer.Dts.Runtime.DTSExecResult.Success,
                Failure = Microsoft.SqlServer.Dts.Runtime.DTSExecResult.Failure
            };
            #endregion
    
            public void Main()
            {
                int ErrorFlag = 0;
    
                // Try-Catch block 
                try
                {
                    int RowCount = 0;
                    bool fireAgain = true;
                    string SQLCommandText = "SELECT ColumnA = 1, ColumnB = 'A' UNION SELECT ColumnA = 2, ColumnB = 'B' UNION SELECT ColumnA = 3, ColumnB = 'C';";
    
                    SqlConnection SQLConnection = new SqlConnection("Data Source=LocalHost;Initial Catalog=master;Integrated Security=SSPI;Application Name=SSIS-My Package Name;Connect Timeout=600");
                    SqlCommand SQLCommand = new SqlCommand(SQLCommandText, SQLConnection);
                    SQLCommand.CommandTimeout = 60 * 60;
                    SqlDataAdapter SQLDataAdapter = new SqlDataAdapter(SQLCommand);
                    DataTable dt = new DataTable();
                    SQLDataAdapter.Fill(dt);
                    SQLConnection.Close();
                    RowCount = dt.Rows.Count;
    
                    Dts.Events.FireInformation(0, "DataTable Rows", RowCount.ToString(), "", 0, ref fireAgain);
    
                    StreamWriter sw = new StreamWriter("C:\\Test.csv", false);
                   
                    // Write the header.
                    sw.Write("Today's date is " + DateTime.Now.ToLongDateString());
    
                    // Write the column headers.
                    sw.Write(sw.NewLine);
                    int iColCount = dt.Columns.Count;
                    for (int i = 0; i < iColCount; i++)
                    {
                        sw.Write(dt.Columns[i]);
                        if (i < iColCount - 1)
                        {
                            sw.Write(",");
                        }
                    }
    
                    // Write the details.
                    sw.Write(sw.NewLine);
                    foreach (DataRow dr in dt.Rows)
                    {
                        for (int i = 0; i < iColCount; i++)
                        {
                            if (!Convert.IsDBNull(dr[i]))
                            {
                                sw.Write(dr[i].ToString());
                            }
                            if (i < iColCount - 1)
                            {
                                sw.Write(",");
                            }
                        }
                        sw.Write(sw.NewLine);
                    }
    
                    // Write the footer.
                    sw.Write("Row count: " + RowCount.ToString());
    
                    sw.Close();
                }
    
                catch (SqlException e)
                {
                    Dts.Events.FireError(0, "SqlException", e.Message, "", 0);
                    ErrorFlag = 1;
                }
    
                catch (IOException e)
                {
                    Dts.Events.FireError(0, "IOException", e.Message, "", 0);
                    ErrorFlag = 1;
                }
    
                catch (Exception e)
                {
                    Dts.Events.FireError(0, "Exception", e.Message, "", 0);
                    ErrorFlag = 1;
                }
    
                // Return results. 
                if (ErrorFlag == 0)
                {
                    Dts.TaskResult = (int)ScriptResults.Success;
                }
                else
                {
                    Dts.TaskResult = (int)ScriptResults.Failure;
                } 
    
            }
        }
    }
