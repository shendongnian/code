     string coordinateTxt = @" -82.9494547,36.2913021,0
     -83.0784938,36.2347521,0
     -82.9537782,36.079235,0";
    
                string[] coordinatesVal = coordinateTxt.Replace(",", "*").Trim().Split(new string[] { "*0", Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                string result = string.Join(",", coordinatesVal).Replace("*", " ");
                Console.WriteLine(result);
