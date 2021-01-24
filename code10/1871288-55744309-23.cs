    public void M(int i) {
        Action<int> inner = x =>
        {
            int j = x + i;
         	Console.WriteLine(j);   
        };
        
        inner(i + 1);
    }
