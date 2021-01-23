    public class DebugHandler<T>{
        public DebugHandler(T obj){
            InnerObject = obj;
        }
        public T InnerObject {get; private set;}
        
    }
    public void addVariable<T>(String index, DebugHandler<T> obj) 
    {
        //store Object here...
        debugStrings.Add(index, obj);                        
    }
