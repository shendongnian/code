    foreach(var dv in readResult.Results)
    {
    	Console.WriteLine("The Value of InStr = {0}", dv.Variant.Value);
    	Console.WriteLine("The Value of InStr = {0}", dv.Variant.ReadValueId); // This line shows how to access ReadValueId.
    	// You can access other properties same as above
    }
