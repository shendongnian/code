    public abstract class AbstractDebugHandler<T>{
        public AbstractDebugHandler(T obj){
            InnerObject = obj;
        }
        public T InnerObject {get; private set;}
        public abstract string GetDebugString();
        
    }
    public void addVariable<T>(String index, DebugHandler<T> obj) 
    {
        debugStrings.Add(index, obj);                        
        //to get debugString use
        string debugValue = obj.GetDebugString();
        // will always geht the current Value of the defined Object
    }
