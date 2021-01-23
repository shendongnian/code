    Queue<string> _items = new Queue<string>();
    
    public void WriteLog(string value)
    {
        _items.Enqueue(value);
        if(_items.Count > 100)
            _items.Dequeue();
    }
