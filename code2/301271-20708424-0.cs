    [Guid("6A2E9B00-C435-48f8-AEF1-747E9F39E77A")]
    public interface IGameHelper
    {
        string getInfo();
    }
    
    public class GameHelper : IGameHelper
    {
        public string getInfo()
        {
           return "Hello World";
        }
    }
