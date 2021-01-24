    var timer = new System.Threading.Timer(
        e => OverwriteText(),  
        null, 
        TimeSpan.Zero, 
        TimeSpan.FromMinutes(2)
    );
    
    private void OverwriteText()
    {
       string txt = Convert.ToString(TotCostLong);
       using (FileStream fs = new FileStream("total-cost.txt", FileMode.Truncate))
       {
    	   using (StreamWriter writer = new StreamWriter(fs))
    	   {
    		   writer.Write(txt);
    	   }
       }
    }
