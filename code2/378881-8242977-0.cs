    var query = rep.GetIp()  // in this line i have the error
               .Where(x => x.CITY == CITY)
               .GroupBy(y => o.Fam)
               .Select(z => new IpDTO
                            {
                                IId = z.Key.Id,
                                IP = z.Select(x => x.IP).Distinct()
                            });
    foreach (var dto in query)
    {
        foreach (ip in dto.IP)
        {
            PAINTIP(ip);
        }
    }
