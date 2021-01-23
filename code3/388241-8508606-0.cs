    public interface IAccess {
    }
    public interface IAccess<T> : IAccess {
    }
    public abstract class Access<T>
    {
        private IAccess accessBehavior;
        public Access()
         {
             FileAccess fa = new FileAccess();
             accessBehavior = fa;
         }
     }
