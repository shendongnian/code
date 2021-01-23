    System.Threading.Timer MyTimer;
    public void Start()
    {
        MyTimer = new Timer((s) =>
            {
                DoSomeWork();
            }, null, 15000, 15000);
    }
