    private readonly object _sync = new object();
    private int _myCount = 0;
    private bool _canIncrement = true;
    void IncrementCount()
    {
        lock (_sync)
        {
            while (!_canIncrement)
            {
                Monitor.Wait(_sync);
            }
            _myCount++;
        }
    }
    void OverwriteCount(int newValue)
    {
        lock (_sync)
        {
            _canIncrement = false;
            _myCount = newValue;
        }
    }
    void OnTimer()
    {
        lock (_sync)
        {
            Console.WriteLine(_myCount);
            _canIncrement = true;
            Monitor.PulseAll(_sync);
        }
    }
