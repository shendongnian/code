     HitTestResult result;
     try
     {
        result = this.HitTest( e.X, e.Y, ChartElementType.DataPoint);
     }
     catch(Exception e)
     {
     #if !DEBUG
        //This happens, we don't care!
     #endif
     }  
