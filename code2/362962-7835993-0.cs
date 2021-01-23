    public List<string> DoSomething(int input)
    {
        List<string> results = new List<string>();
        DoSomethingImpl(input, results);
        return results;
    }
    private void DoSomethingImpl(int input, List<T> results)
    {
        // For example...
        if (input == 0)
        {
            return results;
        }
        results.Add("Foo");
        DoSomethingImpl(input - 1, results);        
    }
