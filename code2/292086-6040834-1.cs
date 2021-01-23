    void m()
    {
       b bee=new b();    
       Excel.Application oXL; // not initialized here!
       Excel._Workbook oWB;   // not initialized here!
       b.write(oXL,oWB);      // calling with uninitialized values! 
    }
   // ...
    class b
    {
       static b() 
       {
           
           // here you declare two local variables not visible outside of your 
           // static constructor.
           Excel._Application oXL = new Excel.Application();
           Excel._Workbook oWB = (Excel._Workbook)(oXL.Workbooks.Add(Type.Missing));
       }
       // oXL here is a parameter, meaning it is completely different from
       // the local oXL in your static constructor
       void write( Excel.Application oXL, Excel._Workbook oWB)
       {
            oXL.Visible = true; 
       }
     }
