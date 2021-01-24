    List<string> inputList = new List<string> {"add", "subtract", "multiply"};
     
    var builder = new System.Dynamic.ExpandoObject() as IDictionary<string, Object>;
     
    foreach(var val in inputList)
    {
       builder.Add(val, $"{val}: some value here");	
    }	
     
    var output = (dynamic)builder;
     
    Console.WriteLine(output.add);
    Console.WriteLine(output.subtract);
    Console.WriteLine(output.multiply);
