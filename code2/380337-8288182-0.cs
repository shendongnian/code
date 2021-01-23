    private Queue<string> data = new Queue<string>();
    private void Rx_GetData(e)
    {
        var rxString = e.ReadExisting();
        data.Enqueue(rxString);   
    }
    private void BackgroundWorker_DoWork()
    {
        while(true)
        {
            if(data.Count > 0)
            {
                var str = data.Dequeue();
                FormatString(str);
            }
        }
    }
