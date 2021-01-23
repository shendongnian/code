       Transaction_Time tranTme = new Transaction_Time(); 
       ....
       Session["Transaction"] = tranTme; 
       ....
       Transaction_Time dstTranTime = Session["Transaction"] as Transaction_Time; 
       if (dstTranTime == null)
           System.Dignostics.Trace.WriteLine("Ups! Expecting Transaction_Time, but got {0}", Session["Transaction"] );
