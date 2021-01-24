    //Parameter listOfArrays contains 0-n arrays of strings
    public List<string> FlattenLists(List<string[]> listOfArrays)
    {
        var returnValue = new List<string>();
        foreach (var array in listOfArrays)
        {
            returnValue.AddRange(array);
    
        }
        return returnValue;
    }
