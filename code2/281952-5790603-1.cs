    public OperationResult GetResult(int id)
    {
      if (id == 0)
      {
        return new OperationResult(false, new List<string>{"Error"});
      }
      if (id < 400)
      {
        var errors = new List<string>{"Error"};
        if (id >200)
           errors.Add("Error");
        return new OperationResult(false, errors);
      }
    }
