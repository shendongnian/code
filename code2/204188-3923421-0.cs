    public interface IFoo
    {    
      /// <summary>
      /// Lol
      /// </summary>
      /// <exception cref="FubarException">Thrown when <paramref name="lol"> 
      /// is <c>null</c></exception>
      /// <remarks>Implementors, pretty please throw FE on lol 
      /// being null kthx</remarks>
      void Bar(object lol);
    }
