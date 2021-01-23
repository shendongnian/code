    public void Add(int value)
    {
        Element newElement = new Element();
        newElement.Value = value;
  
        Element rootCopy = Root;
        Root = newElement;
        newElement.Next = rootCopy;
        Console.WriteLine(newElement.Value);
    }
