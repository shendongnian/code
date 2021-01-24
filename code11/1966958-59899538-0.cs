var listVU = _context.AVu
                 .OrderByDescending(r => r.UpdateDate)
                 .SkipWhile(p => !p.VuId.Equals("NP-A6666"))
                 .Select(x => new AVut
                 {
                     VuId = x.VuId
                 })
                 .Take(50)
                 .AsNoTracking()
                 .ToListAsync();
Skipwhile runs sequentially through the enumerable, skipping elements where the predicate returns true - once the predicate returns false, in this case when the VuID = "NP-A6666", the remaining elements are returned as a new enumerable. 
If you then want to get everything up to `VuID.Equals("NP-A6717")`, you can do the same thing with `TakeWhile` instead of `Take(50)`:
var listVU = _context.AVu
                 .OrderByDescending(r => r.UpdateDate)
                 .SkipWhile(p => !p.VuId.Equals("NP-A6666"))
                 .Select(x => new AVut
                 {
                     VuId = x.VuId
                 })
                 .TakeWhile(p => !p.Equals("NP-A6717"))
                 .AsNoTracking()
                 .ToListAsync();
