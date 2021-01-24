    public class MyClass
    {   
        public Location this[int key]
        {
            get { return LocationsDict.ContainsKey(key) ? LocationsDict[key] : null; }
    
            set 
            {     
            	if (LocationsDict.ContainsKey(key))
        			LocationsDict[key] = value;
    			else
        			LocationsDict.Add(key, value);
            }
        }
    }
    
    var gotest = new MyClass();
    gotest[0] = new Location(){....};
