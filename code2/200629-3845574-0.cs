    public interface IObjectBase
    {
       bool HandleAction(string verb,string [] params)
    }
    
    public class Bottle: IObjectBase
    {
       bool HandleAction(string verb,string [] params)
       {
         //analyze verb and params to look for appropriate actions
         //handle action and return true if a match has been found
       }
    }
