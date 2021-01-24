      using System.Linq;
      ...
      List<NewData> list = ...
      // Let's generalize a bit if you want, say Q3 period
      int fromMonth = 1;
      int upToMonth = DateTime.Today.Month; 
      list = Enumerable
        .Range(fromMonth, upToMonth - fromMonth + 1)
        .Select(month =>
              list.FirstOrDefault(item => item.MONTH == month)
           ?? new NewData() { MONTH = month,       // Omitted month 
                              NEW_REC_COUNT = 0 }) // Default value
        .ToList();
