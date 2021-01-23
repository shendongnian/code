    public interface ITheyHaveInCommon
    {
       string Name;
       string GetOtherValue();
       int SomethingElse;
    }
    
    public class Person : ITheyHaveInCommon
    {
      // rest of your delcarations for the required contract elements
      // of the ITheyHaveInCommon interface...
    }
    
    public class Country : ITheyHaveInCommon
    {
      // rest of your delcarations for the required contract elements
      // of the ITheyHaveInCommon interface...
    }
    
    
    public static class MyGlobalFunctions
    {
       public static string CommonFunction1( ITheyHaveInCommon incomingParm )
       {
          // now, you can act on ANY type of control that uses the 
          // ITheyHaveInCommon interface...
          string Test = incomingParm.Name
                      + incomingParm.GetOtherValue()
                      + incomingParm.SomethingElse.ToString();
    
          // blah blah with whatever else is in your "huge" function
    
          return Test;
       }
    }
