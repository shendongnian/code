    namespace Frobber
    {
      public interface IBlob 
      {
        int Blob { get; }
      }
      public static class MyExtensions
      {
        public static int AddOne(this IBlob b)
        {
          return b.Blob + 1;
        }
      }
    }
    ... elsewhere ...
    using Frobber;
    ...
    IBlob b = whatever();
    int x = b.AddOne();
