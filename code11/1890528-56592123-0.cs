    var result = data
        .Aggregate(
            new List<KeyValuePair<DateTimeRange, List<AtmRecord>>>(),
            (accumulator, atmRecord) => {
                var segment = accumulator.FirstOrDefault(
                    v => atmRecord.ATMID == v.Value.First().ATMID && 
                        atmRecord.FromDateTime <= v.Key.To &&
                        atmRecord.ToDateTime >= v.Key.From);
    
                if (segment.Key == null)
                {
                    accumulator.Add(new KeyValuePair<DateTimeRange, List<AtmRecord>>(
                        new DateTimeRange(atmRecord.FromDateTime, atmRecord.ToDateTime),
                        new List<AtmRecord>() {atmRecord}));
    
                    return accumulator; 
                }
    
                if (atmRecord.FromDateTime < segment.Key.From)
                {
                    segment.Key.From = atmRecord.FromDateTime;
                }
    
                if (atmRecord.ToDateTime > segment.Key.To)
                {
                    segment.Key.To = atmRecord.ToDateTime;
                }                        
    
                segment.Value.Add(atmRecord);
    
                return accumulator;
            },
            accumulator => {
                return accumulator
                    .Select(v => new 
                    {
                        Atmid = v.Value.First().ATMID,
                        St_Comp = v.Value
                            .Select(r => (r.StatusId, r.ComponentId))
                            .ToArray(),
                        FromDateTime = v.Key.From,
                        ToDateTime = v.Key.To
                    });
            })
            .ToArray();
    
    /* result: 
    [0]:{ Atmid = 4, St_Comp = {(int, int)[2]}, FromDateTime = {2019-01-01 6:20:00 p.m.}, ToDateTime = {2019-01-01 6:45:00 p.m.} }
    Atmid [int]:4
    FromDateTime [DateTime]:{2019-01-01 6:20:00 p.m.}
    St_Comp:{(int, int)[2]}
    [0]:(1, 3)
    [1]:(2, 5)
    ToDateTime [DateTime]:{2019-01-01 6:45:00 p.m.}
    
    [1]:{ Atmid = 5, St_Comp = {(int, int)[2]}, FromDateTime = {2019-01-01 6:00:00 p.m.}, ToDateTime = {2019-01-01 6:45:00 p.m.} }
    Atmid [int]:5
    FromDateTime [DateTime]:{2019-01-01 6:00:00 p.m.}
    St_Comp:{(int, int)[2]}
    [0]:(3, 2)
    [1]:(1, 2)
    ToDateTime [DateTime]:{2019-01-01 6:45:00 p.m.}
    
    [2]:{ Atmid = 5, St_Comp = {(int, int)[1]}, FromDateTime = {2019-01-01 6:46:00 p.m.}, ToDateTime = {2019-01-01 6:50:00 p.m.} }
    Atmid [int]:5
    FromDateTime [DateTime]:{2019-01-01 6:46:00 p.m.}
    St_Comp:{(int, int)[1]}
    [0]:(6, 5)
    ToDateTime [DateTime]:{2019-01-01 6:50:00 p.m.}
     */
