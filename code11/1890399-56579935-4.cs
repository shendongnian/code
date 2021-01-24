    public IEnumerable<ViewClaim> Get()
    {
            var principal = User as ClaimsPrincipal;
            return  from c in principal.Claims
                select new ViewClaim
                {
                    Type = c.Type,
                    Value = c.Value
                };
    }
