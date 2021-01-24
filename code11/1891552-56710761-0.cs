cs
public void Main()
        {
	    try{	
                string path = Dts.Variables["User::varERMLoadTxt"].Value.ToString();
            
	  	if (File.Exists(path))
		{
		    using (StreamReader sr = File.OpenText(path))
        	    {
          		string line = File.ReadAllText(path);
	               	string[] lines = line.Split(',');
	
                	if(lines[0].Equals("load", StringComparison.CurrentCultureIgnoreCase))
       	        		Dts.Variables["User::varIsLoad"].Value = true;
      	 		else if (lines[0].Equals("update", StringComparison.CurrentCultureIgnoreCase))
      	 			Dts.Variables["User::varIsUpdate"].Value = true;
                
			Dts.Variables["User::varCommand"].Value = lines[0].ToString();
                	Dts.Variables["User::varAnalysisDate"].Value = lines[1].ToString();
                	sr.Close();
            	     }
       		}	
	    	Dts.TaskResult = (int)ScriptResults.Success;	
	    }catch(Exception ex){
	        Dts.FireError(0,"An error occured", ex.Message,String.Empty, 0);
                Dts.TaskResult = (int)ScriptResult.Failure;
 
            }
        }
enum ScriptResults
{
    Success = Microsoft.SqlServer.Dts.Runtime.DTSExecResult.Success,
    Failure = Microsoft.SqlServer.Dts.Runtime.DTSExecResult.Failure
};
