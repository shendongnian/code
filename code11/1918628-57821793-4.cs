    private int unlockSlot = 1;
    public int UnlockSlot
    {
        get
        {
            return unlockSlot;
        }
        // you can additionally make the setter private so only this class
        // can change the value while other classes have only read permissions
        /*private*/
        set
        {
            unlockSlot = value;
            UpdateItemSlots();
        }
    }
    
