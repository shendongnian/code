    IElementProcessor _elementProcessor;
    public List<int> Process(int input)
    {
        List<int> outputList = new List<int>();
    
        List<int> list = this.dependency1.GetSomeList(input);
        foreach(int element in list)
        {
            // ... Do some procssing to element
            _elementProcessor.ProcessElement(element);
    
            //Do some more processing
            int processedInt = this.dependency2.DoSomeProcessing(element);
    
            // ... Do some processing to processedInt
            _elementProcessor.ProcessInt(processedInt);
    
            outputList.Add(processedInt);
        }
        return outputList;
    }
