    public interface IStrategy
        {
          string GetChildClassName();
        }
    public class Strategy : IStrategy``
        {
    public string GetChildClassName()
         {
        return this.GetType().Name;
         }
        }
