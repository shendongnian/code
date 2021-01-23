    IWSMan wsman = new WSManClass();
    IWSManConnectionOptions options = (IWSManConnectionOptions)wsman.CreateConnectionOptions();                
    if (options != null)
    {
    	try
    	{
    		// options.UserName = ???;  
    		// options.Password = ???;  
    		IWSManSession session = (IWSManSession)wsman.CreateSession("http://SG-S8-64-test20:5985/wsman", 0, options);
    		if (session != null)
    		{
    			try
    			{
    				// retrieve the Win32_Service xml representation
    				var reply = session.Get("http://schemas.microsoft.com/wbem/wsman/1/wmi/root/cimv2/Win32_Service?Name=winmgmt", 0);
    				// parse xml and dump service name and description
    				var doc = new XmlDocument();
    				doc.LoadXml(reply);
    				foreach (var elementName in new string[] { "p:Caption", "p:Description" })
    				{
    					var node = doc.GetElementsByTagName(elementName)[0];
    					if (node != null) Console.WriteLine(node.InnerText);
    				}
    			}
    			finally
    			{
    				Marshal.ReleaseComObject(session);
    			}
    		}
    	}
    	finally
    	{
    		Marshal.ReleaseComObject(options);
    	}
    }
