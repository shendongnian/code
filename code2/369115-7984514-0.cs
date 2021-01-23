    public class ResultState<T>
    {
      public T ResultValue { get; set; }
      public Exception ExceptionThrown { get; set; }
      public bool IsValid { get; set; }
      public string FriendlySummary  { get; set; }
      // whatever else properties you think are needed
    }
    public interface IResultState<T>
    {
      public T ResultValue { get; }
      public Exception ExceptionThrown { get; }
      public bool IsValid { get; }
      public string FriendlySummary  { get; }
      // whatever else properties you think are needed
    }
    public IResultState<List<Balance>> GetBalanceFinale(Periode periode)
    {
      ResultState<List<Balance>> result = new ResultState<List<Balance>>();
      try
      {
        if (periode == null 
            || periode.DateStart >= DateTime.Now 
            || isBalanceFinished(periode.PeriodeID))
        {
          result.IsValid = false;
          result.FriendlySummary = "Periode is in an invalid state.";
        }
    
        //My other code...
        result.ResultValue = new List<Balance>();
        result.ResultValue.Add(...);
      }
      catch(Exception ex)
      {
        result.IsValid = false;
        result.Exception = ex;
        // Ambigious is bad.. so for bad example..
        result.FriendlySummary = "An unknown exception happened.";    
      }
    }
