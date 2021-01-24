    public class SodaVendorClass{
      private int CustBalance = 0;
    //a machine holds 10 cans of soda
    private int SodaCanCount = 5;
     //A soda costs 1 dollar
    //private int sodaCost = 1;
    public int _SodaCanCount
    {
        get
        {
            return SodaCanCount;
        }
    }
    public int _CustBalance
    {
        get
        {
            return CustBalance;
        }
    }
     public SodaVendorClass(int cancount, int sodacost){
       SodaCanCount=cancount;
       sodaCost=sodacost;
     }
    }
    
    //creating a object of Sodavendorclass
    Sodavendorclass obj=new Sodavendorclass(0,0); //Provided value for class property 
