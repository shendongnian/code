    char[] ops = new [] {'*','/','+','-'};
    foreach(string opA in ops)
     foreach(string opB in ops)
      foreach(string opC in ops)
       foreach(string opD in ops)
        foreach(string opZ in new []{'-',' '}) {
         string expression = opZ + 1 + opA + 3 + opB + 5 + opC + 7 + opD + 9;
         DataTable dummy = new DataTable();
         double result = Convert.ToDouble(dummy.Compute(expression, string.Empty));
         if (result == 3)
           Debug.WriteLine(expression + " = 3");
         if (result == 47)
           Debug.WriteLine(expression + " = 47");
         if (result == 18)
          Debug.WriteLine(expression + " = 18");
        } 
