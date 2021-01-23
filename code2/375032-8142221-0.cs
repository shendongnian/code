    class Parameter
    {
     public Parameter(Control control)...
     public string name;
     public bool neededBasedOnControl()...
     public string valueByControl()...
    }
    
    List<Parameter> allParameters = new List<Parameter>();
    allParameters.Add(new Parameter(myControl42);
    
    ...
    StringBuilder args;
    foreach(var p in allParameter)
    {
      if (p.neededBasedOnControl())
      {
        args.Format(p.name, p.valueByControl);
      }
    }
