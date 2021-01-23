    public Tuple<string, bool> TryGetBalanceFinale(Periode periode, out List<Balance> list)
    {
        // return false if anything is wrong, and include message in the returned Tuple
    }
    // an anonymous type approach
    public object TryGetBalanceFinale(Periode periode, out List<Balance> list)
    {
        return new {
           Successful = false,
           Message = // reason why here
        };
    }
    // a functional approach
    public List<Balance> list GetBalanceFinale(Periode periode, Action<String> messageAct)
    {
       // when something is wrong, do:
       messageAct("Something went wrong..."); 
    }
   
