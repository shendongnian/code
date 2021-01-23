    var result1 = dc.Promotions.Where(p => p.Source == source).
        Select(p => new Promotion() {
            Code = p.Code,
            BrokerId = p.BrokerId, // add id property for intermediate results
        }).ToList();   
    var result2 = RDdc.Brokers.ToList();
    var finalResult = result1.Where(p => result2.Contains(b => b.BrokerId == p.BrokerId)).Select(p => new Promotion{
            Code = p.Code,
            BrokerName = result2.Single(b => b.BrokerId == p.BrokerId).Name,
        });
