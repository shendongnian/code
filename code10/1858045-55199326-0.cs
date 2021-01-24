    abstract class BaseClass 
    {
        public T Get<T>(string name)
        {
            // Do appropriate error handling here (wrong name, wrong case, sub-nodes, ...)
            var field = GetType().GetField(name);
            return (T)field.GetValue(this);
        }
    }
  
    public class YourConcreteJsonResultType: BaseClass
    {
        public int JsonVarName;
    }
    
    public BaseClass RequestWeb(string URL)
    {
        //...
    }
    BaseClass x = RequestWeb("someurl.html");
    int y = x.Get<int>("JsonVarName");
