    public class MyCustomDataProvider : AuditDataProvider
    {
        public override object InsertEvent(AuditEvent auditEvent)
        {
            var json = auditEvent.ToJson();
            // ...
        }
    }
