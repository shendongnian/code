    public void GetPeriod(AddressProgram program, out DateTime startDate, out DateTime endDate)
    {
        var outs = WrapServiceMethod(() => 
            {
                DateTime sd;
                DateTime ed;
                Service.GetPeriod(program, out sd, out ed));
                return new {sd, ed};
            }
        startDate = outs.sd;
        endDate = outs.ed;
    }
