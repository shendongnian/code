    public interface IRequest
    {
        int RequestType { get; set; }
        string Name { get; set; }
        void ValidateFields();
    }
Two types of Request
    public class StandardRequest : IRequest
    {
        public int RequestType { get ; set ; }
        public string Name { get ; set; }
        public void ValidateFields()
        {
            //validation logic
        }
    }
    public class SpecialRequest:  IRequest
    {
        public string Desc { get; set; }
        public int RequestType { get; set; }
        public string Name { get; set; }
        public void ValidateFields()
        {
            //validation logic
        }
    }
Factory to create the Request objects
    public class RequestFactory
    {
        public static IRequest CreateRequest(string requestTypeStr)
        {
            switch (requestTypeStr)
            {
                case "0": return new SpecialRequest();
                default: return new StandardRequest();
            }
        }
    }
Class to handle the interactions of the `IRequest` object, aptly named `RequestInteractions`, I know a poor name choice! 
This class is what validates and saves the requests.
    public class RequestInteractions
    {
        private IRequest _requestObj;
        private Repository _repository;
        public RequestInteractions(IRequest requestObj, Repository repository)
        {
            _requestObj = requestObj;
            _repository = repository;
        }
        public bool ValidateAndSave()
        {
            try
            {
                _requestObj.ValidateFields();
                _repository.SaveRequest(_requestObj);
                return true;
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
Repository - like I said, this needs to be fleshed out. The IRequest (through the DTO) should be able to tell you how it needs to be persisted. You'll have to fill this in.
    public class Repository
    {
        public void SaveRequest(IRequest requestObject)
        {
            //The respective DTO should help you figure out what to save based on the type of IRequest
        }
    }
Tying it all together
            var repository = new Repository();
            var requestObject = RequestFactory.CreateRequest("");
            var requestInteractions = new RequestInteractions(requestObject,repository);
            requestInteractions.ValidateAndSave();
> Benefit of this approach - You need to create a new Request class (and
> a DTO) when you get a new Request to add to the system, the rest of
> the plumbing need not be touched. 
> 
> Downside - Well, a lot of code compared to what you have.
