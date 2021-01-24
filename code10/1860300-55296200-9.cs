        var results = db.SearchEntities.Where(x => !string.IsNullOrWhiteSpace(x.EventTitlePrimaryLang))
                                    .AsQueryable();    
        foreach(var r in results) {
            var langSplit = s.EventTitlePrimaryLang.Split(' ');
            foreach(var val in langSplit) {
                results = from a in results
                        where SqlFunctions.SoundCode(val) == SqlFunctions.SoundCode(srQuery)
                        select a;
            }
        }
        return results.ToList();
