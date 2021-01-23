     public IEnumerable<IMyClass> ConvertItems(List<MyClass> input)
     {
        foreach (var item in input)
        {
            yield return (IMyClass)item;
        }
     } 
