    using System;
    using System.Collections.Generic;
    using System.Web.UI;
    
    public static class Logger
    {
    private static readonly Page Pge = new Page();
    		private static readonly string Path = Pge.Server.MapPath("~/yourLogPath/Log.txt");
    		private const string LineBreaker = "\r\n\r======================================================================================= \r\n\r";
    
    public static void LogError(string myMessage, Exception e)
    {
    	const LogSeverity severity = LogSeverity.Error;
    	string messageToWrite = string.Format("{0} {1}: {2} \r\n\r {3}\r\n\r {4}{5}", DateTime.Now, severity, myMessage, e.Message, e.StackTrace, LineBreaker);
    	System.IO.File.AppendAllText(Path, messageToWrite);
    }
    }
