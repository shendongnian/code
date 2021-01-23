    public interface IMyDataInterface
    {
        string loginUser { get; set; }
        string loginPW { get; set; }
    }
    
    public class MyDataLayer : IMyDataInterface
    {
        public MyDataLayer(string login, string pw)
        {
            loginUser = login;
            loginPW = pw;
        }
    }
