    public sealed  class StudentRepository : IDisposable
    {
        ....
        public void Dispose()
        {
            db.Dispose();
        }
    }
