    var records = new [] {
        new { CallTime= DateTime.Now, NumberDialled = 1 },
        new { CallTime= DateTime.Now.AddSeconds(1), NumberDialled = 1 }
    };
    var span = TimeSpan.FromSeconds(10);
    
    // Select for each call itself and all other calls in the next 'span' seconds
    var callInfos = records.AsParallel()
        .Select((r, i) =>
            new
            {
                Record = r,
                Following = records.Skip(i+1)
                                .TakeWhile(r2 => r2.CallTime - r.CallTime < span)
            }
        );
    // Filter the calls that interest us
    var problematic = (from callinfo in callInfos 
                    where callinfo.Following.Any(r => callinfo.Record.NumberDialled == r.NumberDialled)
                    select callinfo.Record)
                    .ToArray();
