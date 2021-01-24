    public interface IAuditSource
    {
        public DateTime Now { get; }
    
        public string LoggedOnUser { get; }
    }
    public class AuditSource : IAuditSource
    {
        public DateTime Now => DateTime.Now;
        public string LoggedOnUser => // however you authenticate
    }
    public MyDbContext(IAuditSource auditSource): base()
    public void MyTestMethod()
    {
        var auditSource = new Mock<IAuditSource>()
        auditSource.Setup(x => x.Now).Returns(new DateTime(2020, 01, 28))
        var context = new MyDbContext(auditSource.Object)
    }
   
