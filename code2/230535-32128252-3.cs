     public int solution(int n) {
          var counter = 0;          
          if (n == 1) return 1;
          counter = 2; //1 and itself      
          int sqrtPoint = (Int32)(Math.Truncate(Math.Sqrt(n)));
          for (int i = 2; i <= sqrtPoint; i++)
          {
            if (n % i == 0)
            {
              counter += 2; //  We found a pair of factors.         
            }       
          }
          // Check if our number is an exact square.
          if (sqrtPoint * sqrtPoint == n)
          {
            counter -=1;
          }
    
          return counter;
        }
