    public interface IMyService
    {
        string ReadCustomerNameById(int id);
    }
    public class MyService : IMyService
    {
        public string ReadCustomerNameById(int id)
        {
            return "Gixabel"; //replace this with your actual implementation
        }
    }
