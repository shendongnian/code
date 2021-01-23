    public static int GetTipNumber()
    {
         int tipNo = 1;
         if (DateTime.Now.Day > 0 && DateTime.Now.Day <= 30)
         {
             tipNo = DateTime.Now.Day;
         }
         else 
         {
             tipNo = 1; // 
         }                
                
         return tipNo;
    }
