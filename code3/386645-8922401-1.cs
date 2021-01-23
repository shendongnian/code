    Microsoft SQL Server Integration Services Script Task
    Write scripts using Microsoft Visual C# 2008.
    The ScriptMain is the entry point class of the script.
    
    using System;
    using System.Text;
    using System.IO;
    using System.Data;
    using Microsoft.SqlServer.Dts.Runtime;
    using System.Windows.Forms;
    
    namespace ST_db04adc927b941d19b3817996ff885c2.csproj
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
    
            /*
    		The execution engine calls this method when the task executes.
    		To access the object model, use the Dts property. Connections, variables, events,
    		and logging features are available as members of the Dts property as shown in the following examples.
    
    		To reference a variable, call Dts.Variables["MyCaseSensitiveVariableName"].Value;
    		To post a log entry, call Dts.Log("This is my log text", 999, null);
    		To fire an event, call Dts.Events.FireInformation(99, "test", "hit the help message", "", 0, true);
    
    		To use the connections collection use something like the following:
    		ConnectionManager cm = Dts.Connections.Add("OLEDB");
    		cm.ConnectionString = "Data Source=localhost;Initial Catalog=AdventureWorks;Provider=SQLNCLI10;Integrated Security=SSPI;Auto Translate=False;";
    
    		Before returning from this method, set the value of Dts.TaskResult to indicate success or failure.
    		
    		To open Help, press F1.
    	*/
    
            public void Main()
            {
                const string dirPath = @"C:\SSIS\Dev\";
    
                DateTime minusoneweek = DateTime.Today.AddDays(-7);
    
                DateTime minusoneday = DateTime.Today.AddDays(-1);
    
                var headerRecord = ("0|" + DateTime.Today.ToString("ddMMyyyy") + "|" + Dts.Variables["LastSequenceNumber"].Value + "|" 
                    + Dts.Variables["FileName"].Value) + "|" + minusoneweek.ToString("ddMMyyyy") + "|" + minusoneday.ToString("ddMMyyyy");
    
                var fileBody = AddHeaderAndFooter.GetFileText(dirPath + "blank.txt");
    
                var trailerRecord = "9|" + AddHeaderAndFooter.CountRecords(dirPath + "blank.txt").ToString();
    
                var outPutData = headerRecord + "\r\n" + fileBody + trailerRecord + "\r\n";
    
                AddHeaderAndFooter.WriteToFile(dirPath + "blank.txt", outPutData);
    
            }
        }
    
        public static class AddHeaderAndFooter
        {
            public static int CountRecords(string filePath)
            {
    
                return (File.ReadAllLines(filePath).Length + 2);  
    
            }
    
            public static string GetFileText(string filePath)
            {
                var sr = new StreamReader(filePath, Encoding.Default);
    
                var recs = sr.ReadToEnd();
    
                sr.Close();
    
                return recs;
            }
    
            public static void WriteToFile(string filePath, string fileText)
            {
    
                var sw = new StreamWriter(filePath, false);
    
                sw.Write(fileText, Encoding.ASCII);
    
                sw.Close();
    
            }
        }
    }
