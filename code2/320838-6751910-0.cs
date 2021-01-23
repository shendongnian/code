     string[] input = {"R.D.    P.N.      X       Y        Rot  Pkg",
    "L5 120910    64.770  98.425   180  SOP8",
    "P4      120911   -69.850  98.425   180  SOIC12",
    "L10     120911   -19.685  83.820   180  SOIC10",
    "P4      120911    25.400  83.820   180  0603",
    "L5      120910    62.484  98.425   180  SOP8",
    "L5      120910    99.100  150.105  180  SOP8"};
        
        var control = new Dictionary<string, int>();
        var result = new List<string[]>();
        
        foreach (var line in input)
        {
           var array = line.Split(' ');
           result.Add(array);
           int occurencies = 0;
           ;
           control[array[0]] = control.TryGetValue(array[0], out occurencies) 
                               ? occurencies == 1 ? -2 : occurencies - 1
        					   : 1;
        }
        
        foreach (var item in result.AsEnumerable().Reverse())
        {
           int value = control[item[0]];
           if (value < 0)
           {
              control[item[0]] = value + 1;
              item[0] = item[0] + value;     
           }
        }
