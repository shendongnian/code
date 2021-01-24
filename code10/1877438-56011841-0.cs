    //For maninpulate a big data string 
    using (StreamWriter NAME = new StreamWriter(pathOriginal, false, Encoding.GetEncoding("ISO-8859-1")))
    {
    
    	foreach (var item in anyList)
    	{
    		var lines = new StringBuilder();
    
    		lines.Append(lines.AnyAttribute);
    
    		NAME.Write(lines.ToString());
    	}
    	
    	NAME.Close();
    }
    
    //To compact
    try
    {
    	FastZip fz = new FastZip();
    	fz.CreateZip(pathDestiny, pathOriginal, true, fileName);
    }
    catch (Exception ex)
    {
    	LoggerHelper.ErroLog(ex);
    }
