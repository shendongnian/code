    namespace YourLibrary.ComponentModel
    {
       /// <summary>
      /// Defines Close method. Use for window, file stream,.... 
      /// </summary>
      public interface IClosable
      {
          /// <summary>
          /// Close of instance (window, file stream,... etc).
          /// </summary>
          void Close();
      }
