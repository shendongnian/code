    public class MyThing
    {
        ISomeInterface _mySingletonObject;
    
        public MyThing(ISomeInterface mySingletonObject)
        {
            _mySingletonObject = mySingletonObject;
        }
    }
