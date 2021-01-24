    interface IOperationAttribute
    {
    }
    [Development]
    public class OperationDevelopment : IOperation
    {
        public Guid OperationId { get; }
    }
    public class DevelopmentAttribute : Attribute, IOperationAttribute
    {
    }
