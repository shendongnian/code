    public static void Main()
	{
		var sql = @"Select SalesOrderID,LineTotal [LineTotal],(Select AVG(LineTotal) from Sales.SalesOrderDetail) as [AverageLineTotal] from Sales.SalesOrderDetail";
		Console.WriteLine(DoesSqlContainSubquery(sql));
	}
    public bool DoesSqlContainSubquery(string sql)
    {
        var regexTest = new Regex(@"\( *Select .*\)", RegexOptions.IgnoreCase);
        var containsSubquery = regexTest.IsMatch(sql);
        return containsSubquery;
    }
