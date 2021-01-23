    public class AuditOperationLogWriterFactory
    {
        private Func<IAuditOperationLogWriter> insertLogWriter;
        private Func<IAuditOperationLogWriter> updateLogWriter;
        public AuditOperationLogWriterFactory(Func<AuditInsertLogWriter> insert, Func<AuditUpdateLogWriter> update)
        {
            insertLogWriter = insert;
            updateLogWriter = update;
        }
        public IAuditOperationLogWriter Create(Operation operation)
        {
            switch (operation)
            {
                case Operation.Insert:
                    return insertLogWriter();
                case Operation.Update:
                    return updateLogWriter();
                default:
                    break;
            }
            return null;
        }
    }
