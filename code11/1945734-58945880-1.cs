     static int Add(int nb1, int nb2)
        {
            
            for (int i = nb1; i < nb2; nb1++) // Loop Condition would never be reached
            {
                int sum = 0;
                if (nb1 % 2 == 0)
                {
                    sum = sum + i;
                    return sum; // Returns before the entire loop is executed
                }
                return i; // Returns before the entire loop is executed
            }
    
           // No execution path when nb1>=nb2
        }
