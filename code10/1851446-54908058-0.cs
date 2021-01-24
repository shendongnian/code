    private void DoParallel()
    {
        //This will over-saturate the ThreadPool unless you use your own TaskScheduler
        for (int i = 0; i < 100; i++)
        {
             Task.Factory.StartNew(() =>
              {
                Console.WriteLine(DateTime.Now.ToString());
                DoSomeWork();
              });
            }
        }
    }
