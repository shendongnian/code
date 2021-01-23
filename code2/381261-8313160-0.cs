    [ServiceContract]
    public interface IServeStuff
    {
        [OperationContract]
        [WebGet(UriTemplate = "/stuff/{id}", 
                ResponseFormat = WebMessageFormat.Json)]
        Stuff GetStuff(string id);
    }
    public class StuffService : IServeStuff
    {
        public Stuff GetStuff(string id)
        {
             return new Stuff(id);
        }
    }
    
