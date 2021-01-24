    public IEnumerable<Tradeline> DedupeTradeline(IEnumerable<Tradeline> tradelines) {
        //split tradeline into manual and non-manual    
        var nonManualTradelines = new List<Tradeline>();
        var manualTradelines = new List<Tradeline>();
        foreach (var t in tradelines) {
            if (t.Source == "MAN")
                manualTradelines.Add(t);
            else
                nonManualTradelines.Add(t);
        }
    
        //check if same reported date is present for dedupe tradelines
        var duplicate = nonManualTradelines.GroupBy(x => new {
            x.ReportedDate,
            x.Account,
            x.AcctType,
            x.Date
        }).Any(g => g.Count() > 1);
    
        IEnumerable<Tradeline> dedupe = nonManualTradelines.GroupBy(t => new {
                    t.Account,
                    t.AcctType,
                    t.Date
                })
                //in case of duplicate tradelines select one with the latest date reported
                .Select(tg => tg.OrderByDescending(t => t.ReportedDate).ThenByDescending(t => Math.Max(t.Late90, Math.Max(t.Late60, t.Late30))).First());
    
        //append manual tradeline to the output of dedupe tradelines
        return dedupe.Union(manualTradelines);
    }
