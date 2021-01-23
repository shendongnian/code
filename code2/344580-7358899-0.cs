    class RetrieveDataClosure
    {
       private Action action;
       private MyClass self;
    
       public RetrieveDataClosure(Action action, MyClass self)
       {
          this.action = action;
          this.self = self;
       }
    
       public void ChartDataCompleted(object se, MyEventArgs ea)
       {
          self._cachedCharts = ea.Result; 
          self.ChartDataRetrieved(ea.Result); 
          if (action != null) 
             action.Invoke(); 
          self._csr = null; 
       }
    }
