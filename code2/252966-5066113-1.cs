    List<string> arrValues = new List<string>();
    for (int i = 0; i < nvc.Count; i++)
    	arrValues.AddRange(nvc.GetValues(i));
    foreach (string value in arrValues)
    	Console.WriteLine(value);
