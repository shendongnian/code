    public class TheInheritor<T> : TheBase where T : TheArgument
    {
       public TheInheritor(T theArgument, Func<T, int> idSelector)
           : base(idSelector(theArgument))
       { 
           ...
       }
    }
