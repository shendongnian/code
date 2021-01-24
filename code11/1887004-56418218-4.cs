using System;
using System.Collections.Generic;
					
public class Program
{
	public static void Main()
	{	
		var l = List();
		Console.WriteLine("Type of enumerable returned by List(): " + l.GetType().FullName);
		Console.WriteLine(l + "wtf"); 
	}
										
	public static IEnumerable<string> List() {
		yield return "abc";
		yield return "xyz";
	}
}
(https://dotnetfiddle.net/H0hl4O)
Assuming the type name of the compiler-generated enumerable object returned by the iterator method _List()_ is "_Program+&lt;List&gt;d\_\_0_", this example would produce the following output:
> Type of enumerable returned by List(): Program+&lt;List&gt;d__0<br>
> Program+&lt;List&gt;d__0wtf
  [1]: https://stackoverflow.com/questions/3236305/do-interfaces-derive-from-system-object-c-sharp-spec-says-yes-eric-says-no-re
