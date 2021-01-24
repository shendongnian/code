    public int Dummy(string id)
    {}
 
    public int DummyFuncContainer(string id)
    {
        var result = Dummy(id);
        return Eight(result);
    }
