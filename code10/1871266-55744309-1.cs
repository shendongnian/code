    public void M(int i) {
        Inner(i + 1);
        
        void Inner(int x)
        {
            int j = x + i;
         	Console.WriteLine(j);   
        }
    }
