     public static int Factorial(int value) {
       // We can't compute factorial for negative and too large values
       if (value < 0 || value > 12)
         throw new ArgumentOutOfRangeException(nameof(value)); // Abnormal termination
        
       if (value == 0)
         return 1;  // Normal termination: special case in which we know the answer
       ... 
     }
