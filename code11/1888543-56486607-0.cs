cs
using System;
namespace ST_3e6cc55d375c472785d01c446ea4bf8b
{
    [Microsoft.SqlServer.Dts.Tasks.ScriptTask.SSISScriptTaskEntryPointAttribute]
    public partial class ScriptMain : Microsoft.SqlServer.Dts.Tasks.ScriptTask.VSTARTScriptObjectModelBase
    {
        
        enum ScriptResults
        {
            Success = Microsoft.SqlServer.Dts.Runtime.DTSExecResult.Success,
            Failure = Microsoft.SqlServer.Dts.Runtime.DTSExecResult.Failure
        };
        public void Main()
        {
            // TODO: Add your code here
            Dts.Variables("FileNameCSV").Value = DateTime.Now.ToString("yyyyMMddHHmmss") + "_MailPieces_" + Dts.Variables("FrequencyType").Value.ToString().Trim() + ".csv";
            Dts.Variables("FileNameZIP").Value = DateTime.Now.ToString("yyyyMMddHHmmss") + "_MailPieces_" + Dts.Variables("FrequencyType").Value.ToString().Trim() + ".zip";
            Dts.TaskResult = (int)ScriptResults.Success;
        }
    }
}
