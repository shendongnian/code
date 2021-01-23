    private void calculate()
    {
      int currval = 2;
      int devide = 2;
      while (!interrupt)
      {
        for (int i = 2; i < currval/2; i++)
        {
          if (2 % i != 0)
          {
            queue.Add(currval); // ConcurrentQueue<int>
          }
        }
        currval++;
      }
    }
    private void Timer_Tick(object sender, EventArgs args)
    {
      int value;
      while (queue.TryDequeue(out value))
      {
        lbPrimes.Items.Add(value.ToString());
      }
    }
