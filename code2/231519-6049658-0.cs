    public class MyRepository
    {
        //Repository Specific Methods
        public DomainObject FindById(...)
        ...
        //"Service" Methods as Delegates
        public Func<DomainObject, SomeResult> ProcessDomainObjectAndGetBackSomeResult
        {
            get
            {
                return ServiceMethodFactory.ProcessDomainObjectAndGetBackSomeResult;
            }
        }
    }
