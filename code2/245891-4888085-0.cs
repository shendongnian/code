    public delegate void SavingObjectHandler(MyObject obj);
    public event SavingObjectHandler SavingObjectEvent;
    public void SavingObject(MyObject obj)
    {
       if (SavingObjectEvent != null) SavingObjectEvent(obj);
    }
