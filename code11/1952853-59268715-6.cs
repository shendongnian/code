    public class Logic
    {
        public Dictionary<string, MyObject> MyObjectDict;
        public List<string> MyObjectNames;
        public Logic()
        {
            var anotherClass = new AnotherClass();
            MyObjectNames = new List<string>() { "Object01", "Object02", "Object03" }; // either add your names here...
            MyObjectNames.Add("Object04");  // or add additional names this way
            //MyObjectNames.AddRange(anotherNameList);	// or add another list or use Linq or whatever
            MyObjectDict = anotherClass.InstantiateAllObjects(MyObjectNames);
            // objects in dict can be accessed directly by their names:
            var object01 = MyObjectDict["Object01"];
        }
    }
    
    // You can access in derived classes or any other classes
    public class DerivedLogic : Logic
    {
        public void SomeFunc()
        {
            var object01 = MyObjectDict["Object01"];
        }
        public void SomeOtherFunc(string objectName)
        {
            var object01 = MyObjectDict[objectName];
        }
    } 
    
    public class AnotherClass
    {
        public Dictionary<string, MyObject> InstantiateAllObjects(List<string> nameList)
        {
            var objectList = new Dictionary<string, MyObject>(nameList.Count);
            foreach (var name in nameList)
            {
                // check if object with name does not already exist.
                if(!objectList.ContainsKey(name)
                {
                    // For your property changed assignment, you can separate the object creation and DIctionary/List assignment
                    var obj = new MyObject() { Name = name };
                    obj.PropertyChanged += (s, e) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));
                    objectList.Add(name, obj);
                }
                // else .... doe something
            }
            return objectList;
        }
    }
