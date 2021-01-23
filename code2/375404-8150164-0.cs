    public class Unit
    {
      public static implicit operator Unit( string val )
      {
         return Unit.Parse( val );
      }
      public static Unit Parse( string unitString )
      {
        // parsing magic goes here
      }
    }
