    public IEnumerable<int> Fibonacci(int x)
    {
        int prev = -1;
        int next = 1;
        for (int i = 0; i < x; i++)
        {
         int sum = prev + next;
            prev = next;
            next = sum;
            yield return sum;
        }
    }
