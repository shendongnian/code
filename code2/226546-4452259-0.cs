    System.Threading.Timer MyTimer = new System.Threading.Timer(CheckCondition, null, 100, 100);
    
    void CheckCondition(object state)
    {
        if (SomeCondition())
        {
            OnSomeCondition();
        }
    }
