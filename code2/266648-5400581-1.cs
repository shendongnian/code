        public class UrlCheckCommand : AsyncCommandBase<string, bool, string>, IUrlCheckCommand
    {
        public override string CorrelationId(string request)
        {
            return request;   //Guid.NewGuid().ToString();
        }
        public override bool Execute(string request)
        {
            return CommandHelper.CheckUrlValidity(request);
        }
    }
