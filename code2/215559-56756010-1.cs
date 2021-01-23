c#
	int i = 1; //would work
    List<string> listTest = new List<string>(); //would work
	Dictionary<string, int> dictTest = new Dictionary<string, int>(); //would work
	Dictionary<int, List<string>> nestTest = new Dictionary<int, List<string>>(); //would fail
	Dictionary<int, List<Dictionary<string, List<object>>>> superNestTest = new Dictionary<int, List<Dictionary<string, List<object>>>>(); //would fail
	Dictionary<int, List<Dictionary<string, int>>> superNestTest2 = new Dictionary<int, List<Dictionary<string, int>>>(); //would fail
In order to solve these issues, I converted the function into a recursive method:
c#
public static class TypeExtensions
{
    public static string GetFriendlyName(this Type type)
	{
	  	string friendlyName = type.FullName;
	   	if (type.IsGenericType)
	   	{
	   		friendlyName = GetTypeString(type);
	   	}
	   	return friendlyName;
	}
	private static string GetTypeString(Type type)
	{
	  	var t = type.AssemblyQualifiedName;
	
	   	var output = new StringBuilder();
	   	List<string> typeStrings = new List<string>();	
	
	   	int iAssyBackTick = t.IndexOf('`') + 1;
	   	output.Append(t.Substring(0, iAssyBackTick - 1).Replace("[", string.Empty));
	   	var genericTypes = type.GetGenericArguments();
	
	   	foreach (var genType in genericTypes)
	   	{
	   		typeStrings.Add(genType.IsGenericType ? GetTypeString(genType) : genType.ToString());
	   	}
	
	   	output.Append($"<{string.Join(",", typeStrings)}>");
	   	return output.ToString();
	}
}
running for the previous examples/test cases yielded the following outputs:
c#
System.Int32
System.Collections.Generic.List<System.String>
System.Collections.Generic.Dictionary<System.String,System.Int32>
System.Collections.Generic.Dictionary<System.Int32,System.Collections.Generic.List<System.String>>
System.Collections.Generic.Dictionary<System.Int32,System.Collections.Generic.List<System.Collections.Generic.Dictionary<System.String,System.Collections.Generic.List<System.Object>>>>
System.Collections.Generic.Dictionary<System.Int32,System.Collections.Generic.List<System.Collections.Generic.Dictionary<System.String,System.Int32>>>
I spent some time trying to resolve the nested types issue so wanted to document this here to ensure anyone else in future can save some considerable time (and headaches!). I have checked the performance as well, and it is in the microseconds to complete (8 microseconds in the case of the last scenario:
> Performance results  
*(Variables names used from original scenario list)*  
"i" | 43uS
"listTest" | 3uS
"dictTest" | 2uS
"nestTest" | 5uS
"superNestTest" | 9uS
"superNestTest2" | 9uS
**Average times after performing the above code 200 times on each scenario**    
  [1]: https://stackoverflow.com/a/32309776/4261713
