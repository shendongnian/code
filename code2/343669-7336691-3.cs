    public class SV
    {
    	private static readonly SV instance = new SV( );
    
    	public Persist<DateTime> FiscalDate;
    	public Persist<decimal> Revenue;
    
    	private SV( )
    	{
    		FiscalDate = new Persist<DateTime>( "FiscalDate" );
    		Revenue = new Persist<decimal>( "Revenue" );
    	}
    
       public static SV Instance
       {
          get 
          {
             return instance; 
          }
       }
    }
