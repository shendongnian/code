    public int GetSum(int a, int b)
    {
        if(a == b)
           return a;
        
        int sum = 0;
        
        for(int i = a; i <=b; i++){
          sum = sum + i;
        }
    
        return sum;
    }
