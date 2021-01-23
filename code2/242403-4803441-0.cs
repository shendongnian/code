        public class TheInheritor : TheBase
        {
            public TheInheritor(TheArgument theArgument) : base(theArgument == null ? -1 : theArgument.TheId)
            {
                  if (theArgument == null)
                  {
                      throw new ArgumentNullException("theArgument");
                  }
        
            }
        }
