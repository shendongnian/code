    void m()
    {
       b bee=new b();    
       b.write();
    }
   // ...
    public class b
    {
       Excel._Application oXL;
       Excel._Workbook oWB;
       public b() 
       {
           
           oXL = new Excel.Application();
           oWB = (Excel._Workbook)(oXL.Workbooks.Add(Type.Missing));
       }
       public void write()
       {
            // do something with cXL and oWB here
       }
     }
