    public class MyMonostateClass
    {
      #region internal, static implementation
        
      private static string dataItem;
        
      private static int someMethod( int foo )
      {
        return 0 ; // do something useful return the appropriate value
      }
        
      #endregion internal, static implementation
        
      #region public instance implementation wrappers
        
      public string DataItem
      {
        get { return dataItem; }
        set { dataItem = value; }
      }
        
      public int SomeMethod( int foo )
      {
        return MyMonostateClass.someMethod(foo);
      }
        
      #endregion public instance implementation wrappers
        
      public MyMonostateClass()
      {
        return ;
      }
        
    }
