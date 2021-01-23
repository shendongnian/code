    private EventHandler itemsProcessed;
    public event EventHandler ItemsProcessed
    {
        add
        {
            itemsProcessed-= value;
            itemsProcessed+= value;
        }
        remove
        {
            itemsProcessed-= value;
        }
    }
