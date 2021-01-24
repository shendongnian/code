IEnumerable <T> FindElements (Func<Object, bool> condition, IEnumerable<T> inputList)
{   
    List<T> outputList = new List<T>();
    foreach(var element in inputList)
    {
        if(condition != null && condition(element))
          outputList.Add(element)
    }
    return outputList;
}
Then, if you call the function given exemplary parameters:
string input[] = {"Test1","Test2"};
foreach(string s in input)
{
   targetList = FindElements(element=>((cast)element).Name.Contains(s), collection)
}
You should get all elements in ```collection``` which name has Test1 or Test2. Cast is of course name of the class which element instantiates.
