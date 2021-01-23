    Queue<Work> queue;
    AutoResetEvent outstandingWork = new AutoResetEvent(false);
    void Enqueue(Work work) 
    {
        lock (queue)
        { 
           queue.Enqueue(work); 
           outstandingWork.Set();
        }
    }
    Work DequeMaybe()
    {
        lock (queue)
        {
           if (queue.Count == 0) return null;
           return queue.Dequeue();
        }
    }
    void DoWork()
    {
       while (true)
       {
          Work work = DequeMaybe();
          if (work == null)
          {
              outstandingWork.WaitOne();
              continue;
          }
          // Do the work.
       }
    }
