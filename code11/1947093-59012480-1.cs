    var claims = new Dictionary<(string, bool), Func<Task<ClaimResult>>>();
    claims.Add(("ARM", true), () => WebService<ARMProduction.WebServiceAWI>.GetClaim(claimParams, _environment.ARMUrl, 
            _environment.TrustOnlineUsername, _environment.TrustOnlinePassword, new ARMProduction.User()));
    claims.Add(("ARM", false), () => WebService<ARMDevelopment.WebServiceAWI>.GetClaim(claimParams, _environment.ARMUrl, 
            _environment.TrustOnlineUsername, _environment.TrustOnlinePassword, new ARMDevelopment.User()));
    var claimResult = await claims[(claimParams.ServiceName, _environment.Production)].Invoke();
