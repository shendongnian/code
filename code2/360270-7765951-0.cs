    // System.Web.Hosting.ISAPIWorkerRequest
    public override string GetRemoteAddress()
    {
        return this.GetServerVariable("REMOTE_ADDR");
    }
