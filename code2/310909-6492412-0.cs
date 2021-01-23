    public static class ErrorLog
    {
    	public static void WriteError(Exception ex)
    	{
    		try {
    			string path = "~/error/logs/" + System.DateTime.Now.ToString("dd-MM-yyyy") + ".txt";
    			if ((!System.IO.File.Exists(System.Web.HttpContext.Current.Server.MapPath(path)))) {
    				System.IO.File.Create(System.Web.HttpContext.Current.Server.MapPath(path)).Close();
    			}
    			using (System.IO.StreamWriter w = System.IO.File.AppendText(System.Web.HttpContext.Current.Server.MapPath(path))) {
    				w.WriteLine(System.Environment.NewLine + "Log Entry : {0}", System.DateTime.Now.ToString(System.Globalization.CultureInfo.InvariantCulture));
    				var page = VirtualPathUtility.GetFileName(HttpContext.Current.Request.Url.AbsolutePath);
    				w.WriteLine("Error in: " +  page);
    				string message = "Message: " + ex.Message;
    				w.WriteLine(message);
    				string stack = "StackTrace: " + ex.StackTrace;
    				w.WriteLine(stack);
    				w.WriteLine("__________________________");
    				w.Flush();
    				w.Close();
    			}
    		} catch (Exception writeLogException) {
    			try {
    				WriteError(writeLogException);
    			} catch (Exception innerEx) {
    				//ignore
    			}
    		}
    	}
    }
