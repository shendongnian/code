    public interface IResult
    {
      // No members
    }
    public void DoSomething(IResult result)
    {
      if (result is DoSomethingResult)
        ((DoSomethingResult)result).DoSomething();
      else if (result is DoSomethingElseResult)
        ((DoSomethingElseResult)result.DoSomethingElse();
    }
