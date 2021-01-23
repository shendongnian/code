    StreamWriter sw = null;
    try
    {
    	sw = File.AppendText(filePath);
    	sw.WriteLine(message);
    }
    catch(Exception)
    {
    }
    finally
    {
    	if (sw != null)
    		sw.Dispose();
    }
