    var result = target.Distinct()
                       .Select(s => new { Word = s, Count = target.Count(w => w == s) })
                       .OrderByDescending(o => o.Count)
                       .Select(o => new Tuple<string, int>(o.Word, o.Count));
    // or in query form
    var result = from s in target.Distinct()
                 let count = target.Count(w => w == s)
                 orderby count descending
                 select new Tuple<string, int>(s, count);
