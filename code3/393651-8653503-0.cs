    var count = dbContext.Table1
                         .Where(entry => entry.Department == "ABC" && 
                                         entry.SkillName != null)
                         .Select(entry => entry.SkillName)
                         .Distinct()
                         .Count();
