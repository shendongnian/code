     HitTestResult result;
     try
     {
        result = this.HitTest( e.X, e.Y, ChartElementType.DataPoint);
     }
     catch(Exception e)
     {       
        if(!Debugger.IsAttached)
        {
            //This happens, we don't care!
        }
     }
