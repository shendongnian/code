    var myResult2 = result.GroupBy(o => o.CreationDate.Month).Select(monthGroup => new
    	{
    		Month = System.Globalization.DateTimeFormatInfo.CurrentInfo.GetMonthName(monthGroup.Key),
    		Accounts = monthGroup.GroupBy(o => o.AccountType).ToDictionary(accountGroup => accountGroup.Key, accountGroup => accountGroup.Count())
    	});
