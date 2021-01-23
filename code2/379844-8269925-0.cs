    public Queue<Action> GetQueue(bool condition)
    {
        var toReturn = new Queue<Action>();
        if (condition)
        {
            toReturn.Enqueue(DoWork1);
            toReturn.Enqueue(DoWork2);
        }
        else
        {
            toReturn.Enqueue(DoWork2);
            toReturn.Enqueue(DoWork1);
        }
        return toReturn;
    }
    
    public void MyExecutingMethod()
    {
        foreach (var action in GetQueue(true))
        {
            action();
        }
    }
    
    public void DoWork1()
    {
                
    }
    
    public void DoWork2()
    {
    
    }
