    public IEnumerable<int> Process(int input)
    {
        foreach(var element in dependency1.GetSomeList(input))
        {
            yield return dependency2.DoSomeProcessing(element);
        }
    }
