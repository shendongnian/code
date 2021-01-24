                string coordinateTxt = @" -82.9494547,36.2913021,0
     -83.0784938,36.2347521,0
     -82.9537782,36.079235,0";
    
                string[] coordinatesVal = coordinateTxt.Trim().Split(new string[] { ",0" }, StringSplitOptions.RemoveEmptyEntries);
                string result = string.Join(" ", coordinatesVal).Replace(Environment.NewLine, "");
                Console.WriteLine(result);
