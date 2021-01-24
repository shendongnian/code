         if(newString == newString2)
to:
         if(newString.Equals(newString2))
your issue would be resolved.
When == is used on an expression of type object, it'll resolve to System.Object.ReferenceEquals.
Equals is just a virtual method and behaves as such, so the overridden version will be used (which, for string type compares the contents).
As a side note, you can also simplify your logic with code like below:
        var x = 121;
        var numStr = x.ToString();
		var numArray = numStr.ToCharArray();
		Array.Reverse(numArray);
		var revStr = new string(numArray);
		Console.WriteLine(numStr + "\n" + revStr);
		
		if(numStr.Equals(revStr))
		{
			Console.WriteLine("true");
		}
		else
		{
			Console.WriteLine("false");
		}
It's likely not the most optimal code, but should be more manageable than your approach.
