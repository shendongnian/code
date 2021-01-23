    public IEnumerable<int> Fibonacci(int x)
    {
        IList<int> fibs = new List<int>()
        int prev = -1;
        int next = 1;
        for (int i = 0; i < x; i++)
        {
         int sum = prev + next;
            prev = next;
            next = sum;
            fibs.Add(sum); 
        }
        return fibs;
    }
