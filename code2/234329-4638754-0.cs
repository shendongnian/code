    var data = new List<Data>
                                 {
                                     new Data() {Name = "one3", Date = new DateTime(2001, 11, 11), Value = 7},
                                     new Data() {Name = "one2", Date = new DateTime(2001, 11, 11), Value = 111},
                                     new Data() {Name = "one2", Date = new DateTime(2011, 11, 11), Value = 7},
                                 };
    
    var result = data.GroupBy(x => x.Name).Select(grouping => grouping.OrderByDescending(x => x.Date).Take(1).FirstOrDefault()).ToList();
