    public class CreamUOW : ICreamUOW
    {
        // No changes to the rest of your code
        public ICreamRepository<CreamModel> Creams
        {
        }
    }
    public interface ICreamUOW : IDisposable
    {
        // So your interface will be
        ICreamRepository<CreamModel> Creams { get; }
    }
