    public void Add(int value)
    {
        Element newElement = new Element();
        newElement.Value = Value;
  
        Element rootCopy = Root;
        Root = newElement;
        newElement.Next = rootCopy;
        Console.WriteLine(newElement.Value);
    }
