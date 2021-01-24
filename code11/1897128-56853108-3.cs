      List<NewData> list = ...
      // Let's generalize a bit if you want, say Q3 period
      int fromMonth = 1;
      int upToMonth = DateTime.Today.Month; 
      list = Enumerable
        .Range(fromMonth, upToMonth - fromMonth + 1)
        .Select(index =>
              list.FirstOrDefault(item => item.MONTH == index)
           ?? new NewData() { MONTH = index,       // Omitted month 
                              NEW_REC_COUNT = 0 }) // Default value
        .ToList();
