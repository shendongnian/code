    public interface IUnitOfWork : IDisposable
    {
        void CommitChanges();
        void RollbackChanges();
    }
    public class MyDataModel : IUnitOfWork
    {
        private bool isDisposed;
        private readonly SqlConnection sqlConnection;
        public MyDataModel()
        {
            sqlConnection = DBConnection.GetConnection();
        }
        // Todo: Implement IUnitOfWork here
        public void Dispose()
        {
            sqlConnection.Dispose();
            isDisposed = true;
        }
        public IRepository<Report> Reports
        {
            get
            {
                return new ReportDbRepository(sqlConnection);
            }
        }
    }
    public class ReportDbRepository : IRepository<Report>
    {
        private readonly SqlConnection sqlConnection;
        public ReportDbRepository(SqlConnection sqlConnection)
        {
            this.sqlConnection = sqlConnection;
        }
        // Todo: Implement IRepository<Report> here using sqlConnection
    }
