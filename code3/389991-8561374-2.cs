    var result = from ipaddress in new[]
    {
      "111.11.11.11",
      "22.22.22.22",
      "22.33.44.55"
      /* or pulled from whatever source */
    }
    .AsParallel().WithDegreeOfParallelism(6)
    let p = new Ping().Send(IPAddress.Parse(ipaddress))
    select new
    {
      site,
      Result = p.Status,
      Time = p.RoundtripTime
    }
    
    /* process the information you got*/
    
