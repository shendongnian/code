    public static class ObjectExt {
        public static int ToInt<T>(this T obj) => Convert.ToInt32(obj);    
    }
    
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
    
        IEnumerable<Tradeline> dedupe = nonManualTradelines.GroupBy(t => new {
                    t.Account,
                    t.AcctType,
                    t.Date
                })
                //in case of duplicate tradelines select one with the latest date reported
                .Select(tg => tg.OrderByDescending(t => t.ReportedDate).ThenByDescending(t => Math.Max(t.Late90.ToInt(), Math.Max(t.Late60.ToInt(), t.Late30.ToInt()))).First());
    
        //append manual tradeline to the output of dedupe tradelines
        return dedupe.Union(manualTradelines);
    }
