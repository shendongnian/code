    if (_environment.Production)
	{
		switch(claimParams.ServiceName)
		{
			case "ARM":
				claimResult = await WebService<ARMProduction.WebServiceAWI>.GetClaim(claimParams, _environment.ARMUrl, _environment.TrustOnlineUsername, _environment.TrustOnlinePassword, new ARMProduction.User());     
				break;
			case "BW":
				claimResult = await WebService<BWProduction.WebServiceBW>.GetClaim(claimParams, _environment.BWUrl, _environment.TrustOnlineUsername, _environment.TrustOnlinePassword, new BWProduction.User());     
				break;
			case "CS":
				claimResult = await WebService<CSProduction.WebServiceCS>.GetClaim(claimParams, _environment.CSUrl, _environment.TrustOnlineUsername, _environment.TrustOnlinePassword, new CSProduction.User());     
				break;
		}
	}
	else
	{
		switch(claimParams.ServiceName)
		{
			case "ARM":
				claimResult = await WebService<ARMDevelopment.WebServiceAWI>.GetClaim(claimParams, _environment.ARMUrl, _environment.TrustOnlineUsername, _environment.TrustOnlinePassword, new ARMDevelopment.User());
				break;
			case "BW":
				claimResult = await WebService<BWDevelopment.WebServiceBW>.GetClaim(claimParams, _environment.BWUrl, _environment.TrustOnlineUsername, _environment.TrustOnlinePassword, new BWDevelopment.User());
				break;
			case "CS":
				claimResult = await WebService<CSDevelopment.WebServiceCS>.GetClaim(claimParams, _environment.CSUrl, _environment.TrustOnlineUsername, _environment.TrustOnlinePassword, new CSDevelopment.User());
				break;
		}
	}
