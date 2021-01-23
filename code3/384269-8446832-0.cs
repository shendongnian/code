	var proxy = new WhatEverYourServiceProxyClassIsNamed();
	try
	{
		//your call logic here
		
		proxy.Close();
	}
	catch (FaultException<BtsSoapException> bse)
	{
		//Get the info you're looking for in the strongly typed soap fault:
		
		proxy.Abort();
	}
	catch (FaultException fe)
	{
		//Do something appropriate for a non-typed soap fault
		
		proxy.Abort();
	}
	finally
	{
		if ((ICommunicationObject)proxy).State != CommunicationState.Closed)
			proxy.Abort();
	}
