     public static void DisplayFortune(string[] fortune, int index)
     {
         if (null == fortune)
             throw new ArgumentNullException(nameof(fortune));
         else if (index < fortune.GetLowerBound(0) || index > fortune.GetUpperBound(0)) 
             throw new ArgumentOutOfRangeException(nameof(index)); 
         WriteLine(fortune[index]);
     }
