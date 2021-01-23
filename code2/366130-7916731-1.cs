    public void SetFirstPlaceId(int value)
    {
        firstPlaceId = value;
        Thread t = new Thread(delegate()
        {
            FirstPlace = setPlaceName(1);
        });
        t.IsBackground = true;
        t.Start();
    }
