	public static IEnumerable<IGrouping<int, StudentInfo>> ExtensionMethod_SomeFunction(this IEnumerable<StudentInfo> list, Func<StudentInfo, bool> selector) 
	{
		return list.GroupBy(x => x.GroupID)
			                      .Where(g => g.Any(selector) )
								  .Select(g => g);
    }
