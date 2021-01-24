    public virtual Task OnFailedAuthentication(IAuthSession session, IRequest httpReq, IResponse httpRes)
    {
        httpRes.StatusCode = (int)HttpStatusCode.Unauthorized;
        httpRes.AddHeader(HttpHeaders.WwwAuthenticate, "{0} realm=\"{1}\"".Fmt(this.Provider, this.AuthRealm));
        return HostContext.AppHost.HandleShortCircuitedErrors(httpReq, httpRes, httpReq.Dto);
    }
