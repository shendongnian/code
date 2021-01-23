    #if DEBUG
      public class UserControlAdmonEntidad : UserControl, IAdmonEntidad
    #else
      public abstract class UserControlAdmonEntidad : UserControl, IAdmonEntidad
    #endif
      {
        ...
        #if DEBUG
        public virtual object DoSomething()
        {
            throw new NotImplementedException("This method must be implemented!!!");
        }
        #else
        public abstract object DoSomething();
        #endif
        ...
      }
