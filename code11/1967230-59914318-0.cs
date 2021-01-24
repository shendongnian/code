    private int _index = 0;
    private List<object> _myList = ...; // assume this list contains some elements
    public void ProcessNextObject()
    {
        if(_index < _myList.Length)
        {
            Process(_myList[_index]);
            _index++;
        }
    }
    private void Process(object o)
    {
        Console.WriteLine("Processing this object!");
    }
