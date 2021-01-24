    all_data = db.SearchEntities.Where(x => !string.IsNullOrWhiteSpace(x.EventTitlePrimaryLang))
                                .AsEnumerable()
                                .Where(s => (s.EventTitlePrimaryLang.Split(' ')
                                                                   .Any(d => SqlFunctions.SoundCode(d)) == SqlFunctions.SoundCode(srQuery)))
                                .ToList();
