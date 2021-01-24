    public class Logic
    {
    	public List<MyObject> MyObjectList;
    	public List<string> MyObjectNames;
    	public Logic()
    	{
    		var anotherClass = new AnotherClass();
    		MyObjectNames = new List<string>() {"Object01", "Object02", "Object03"}; // either add your names here...
    		MyObjectNames.Add("Object04");	// or add additional names this way
    		//MyObjectNames.AddRange(anotherNameList);	// or add another list or use Linq or whatever
    		MyObjectList = anotherClass.InstantiateAllObjects(MyObjectNames);
    	}
    }
    
    public class AnotherClass
    {
    	public List<MyObject> InstantiateAllObjects(List<string> nameList)
    	{
    		var objectList = new List<MyObject>(nameList.Count);
    		foreach (var name in nameList)
    		{
    		  objectList.Add(new MyObject(){Name = name});
    		}
    		return objectList;
    	}
    }
