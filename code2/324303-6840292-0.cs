    //service interface
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        List<string> DoWork(int page, int pageSize, out int totalRecords);
    }
    //service implementation
    public class Service1 : IService1
    {
        public List<string> DoWork(int page, int pageSize, out int totalRecords)
        {
            var l = new List<string>();
            totalRecords = l.Count();
            return l.Skip((page - 1) * pageSize).Take(pageSize).ToList();
        }
    }
