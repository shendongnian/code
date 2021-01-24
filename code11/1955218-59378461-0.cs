C#
public void M() 
{
    using var f1 = new System.IO.MemoryStream(null,true);    
    using var f2 = new System.IO.MemoryStream(null,true);
    using var f3 = new System.IO.MemoryStream(null,true);
}
IL converts it into; 
c#
public void M()
{
	MemoryStream memoryStream = new MemoryStream(null, true);
	try
	{
		MemoryStream memoryStream2 = new MemoryStream(null, true);
		try
		{
			MemoryStream memoryStream3 = new MemoryStream(null, true);
			try
			{
			}
			finally
			{
				if (memoryStream3 != null)
				{
					((IDisposable)memoryStream3).Dispose();
				}
			}
		}
		finally
		{
			if (memoryStream2 != null)
			{
				((IDisposable)memoryStream2).Dispose();
			}
		}
	}
	finally
	{
		if (memoryStream != null)
		{
			((IDisposable)memoryStream).Dispose();
		}
	}
}
Which is same as nested using statements
you can check from here: https://sharplab.io/#v2:CYLg1APgAgTAjAWAFBQMwAJboMLoN7LpGYZQAs6AsgBQCU+hxTUADOgG4CGATugGZx0AXnQA7AKYB3THAB0ASQDysyuIC2Ae24BPAMoAXbuM5rqogK4AbSwBpD58bQDcTRkyKsOPfjGFipMgrKqpo6BkYmZla29o5Obu6eXLx8GCIS0lBySirqWnqGxqYW1nbcDs4JAL7IVUA===
