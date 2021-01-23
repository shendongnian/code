    var recipients = File.ReadAllLines(path)
                 .Select(record => record.Split('|'))
                 .Select(tokens => new
                 {
                     FirstName = tokens[2],
                     LastName = tokens[4],
                     RecordId = tokens[13],
                     Date = Convert.ToDateTime(tokens[17])
                 }
                 )
                 .GroupBy(m => m.RecordId)
                 .Select(grouped => new 
                 {
                     Id = grouped.Key,
                     First3 = grouped.OrderByDescending(x => x.Date).Take(3)
                 }
                 .Dump();
                
