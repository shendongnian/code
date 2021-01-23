    namespace MyProject
    {
      using FirstApi;
      using SecondApi;
      public class SecondAPIAdapter<T2> : MyBaseClass, IMyInterface
        where T2 : SecondAPIAdapter<T2>, new()
      {
        #region IMyInterface Members
        IEnumerable<T> IMyInterface.Search<T>()
        {
          return Search<T2>().Cast<T>();
        }
        #endregion
      }
      //now you simply derive from the APIAdapter class - passing
      //in your derived type as the generic parameter.
      public class MyDerivedClass : SecondAPIAdapter<MyDerivedClass>
      { }
    } 
