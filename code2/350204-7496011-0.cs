    var e = new Expression("basic / workingDays * attendingDays);
    //Set up a custom delegate so NCalc will ask you for a parameter's value
    //   when it first comes across a variable
    e.EvaluateParameter += delegate(string name, ParameterArgs args)
    {
       if (name == "basic")
           args.Result = GetBasicValueFromSomeWhere();
       else if (/* etc. */)
       {
           //....
       }
      
       //Or if the names match up you might be able to something like:
       args.Result = dataRow[name];
    };
      
    var result =  e.Evaluate();
