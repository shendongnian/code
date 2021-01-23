    public IList<int> Fibonacci(int x)
    {
        List<int> result = new List<int>();
        int prev = -1;
        int next = 1;
        for (int i = 0; i < x; i++)
        {
         int sum = prev + next;
            prev = next;
            next = sum;
            result.Add(sum);
        }
        return result;
    }
