    public class AuditOperationLogWriterFactory
    {
        private Dictionary<Operation, Func<IAuditOperationLogWriter>> auditCreator = 
            new Dictionary<Operation, Func<IAuditOperationLogWriter>>();
        public AuditOperationLogWriterFactory(Func<AuditInsertLogWriter> insert,
            Func<AuditUpdateLogWriter> update)
        {
            auditCreator[Operation.Insert] = insert;
            auditCreator[Operation.Update] = update;
        }
        public IAuditOperationLogWriter Create(Operation operation)
        {
            if (auditCreator.ContainsKey(operation))
            {
                return auditCreator[operation]();
            }
            return null;
        }
    }
