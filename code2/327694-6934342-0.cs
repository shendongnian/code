    public void FakeBWTask()
    {
       if (this.TW.CancellationPending) 
          return; 
       foreach (object o in FakeBWTaskSteps())
       {
          // Other repeated logic here....
          if (this.TW.CancellationPending) 
              return; 
       }
    }
    
    private IEnumerable<object> FakeBWTaskSteps()
    {
    
        foreach (var F1 in Fake1)
        {
            yield return null;
    
            foreach (var F2 in Fake2)
            {   
                yield return null;
                foreach (var F3 in Fake3)
                {
                   yield return null;
                }
            }
        }
    }
