    [DataContract]
    [KnownType(typeof(NullReferenceException))]
    [KnownType(typeof(InvalidOperationException))]
    [KnownType(typeof(ApplicationException))]
    [KnownType(typeof(...))] // add one for every type of exception you might need to serialize back, or that might be contained in Exception.InnerException
    public partial class AbstractApplicationCallDto
    {
        ...
