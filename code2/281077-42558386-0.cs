    [EnableClientAccess()]
    public class YourDomainService : DomainService
    {
        protected override void OnError(DomainServiceErrorInfo errorInfo)
        {
                base.OnError(errorInfo);
                customErrorHandler(errorInfo.Error);
        }
        private void customErrorHandler(Exception ex)
        {
                DomainServiceContext sc = this.ServiceContext;
                //Write here your custom logic handling exceptions
        }
    }
