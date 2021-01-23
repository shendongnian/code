    // Publisher side - add methods to add/remove "subscribers":
    public void AddListener(IDatabaseOperation op)   
    {
        lock(syncObj)  // thread safety may be an issue...
            this.listeners.Add(op); 
    }
    private void OnEvent()
    {
        lock(syncObj)
        {
            Parallel.ForEach(this.listeners, l => l.DoOperation());
        }
    }
    
