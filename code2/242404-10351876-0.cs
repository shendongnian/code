    public class TheInheritor : TheBase
    {
       public TheInheritor(TheArgument theArgument, Func<TheArgument, int> idSelector)
           : base(idSelector(theArgument))
       { 
           ...
       }
    }
