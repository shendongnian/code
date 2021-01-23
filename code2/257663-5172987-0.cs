     string test = "test=1 test2=2 test3=3";
     List<string[]> values = new List<string[]>();
     string[] split1 = test.Split(' ');
     foreach (string s in split1)
     {
          string[] split2 = s.Split('=');
          values.Add(new string[]{split2[0],split2[1]});
     }
