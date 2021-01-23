    public bool TryGetBalanceFinale(Periode periode, out List<Balance> list, out string msg)
    {
        // return false if anything is wrong, and have an out parameter for the result & msg
    }
    public Tuple<string, bool> TryGetBalanceFinale(Periode periode, out List<Balance> list)
    {
        // return false if anything is wrong, and include message in the returned Tuple
    }
    public bool TryGetBalanceFinale(Periode periode, out List<Balance> list, out Exception ex)
    {
        // return false if anything is wrong, and have an out parameter for the exception
    }
    // an anonymous type approach
    public object TryGetBalanceFinale(Periode periode, out List<Balance> list)
    {
        return new {
           Successful = false,
           Message = // reason why here
        };
    }
   
  
