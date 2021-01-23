    _worker.DoWork += delegate { DoWork(Dispatcher.CurrentDispatcher); };
    
    ...
    private void DoWork(Dispatcher dispatcher) {
      dispatcher.BeginInvoke(new Action(() => {
        PartialEmployees.Clear();
      });
    }
