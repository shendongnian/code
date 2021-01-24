    public void M(int i) {
        void Inner(int x)
        {
            int j = x + i;
         	Console.WriteLine(j);   
        }
        
        Action<int> inner = Inner;
        inner(i + 1);
    }
