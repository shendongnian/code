    public void DoWork() {
    
      RunSomeBigMethod();
      if (_shouldStop){ return; }
      RunSomeOtherBigMethod();
      if (_shouldStop){ return; }
      //....
    }
----------
