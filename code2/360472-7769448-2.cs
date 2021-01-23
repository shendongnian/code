    public class UnitOfWork
        {
            private SampleDBContext context = new SampleDBContext();
    
            private IUserRepository userRepository;
    
            #region PublicProperties
    
            public IUserRepository UserRepository
            {
                get
                {
                    if (this.userRepository == null)
                    {
                        UserRepository repo = new UserRepository(context);
                    }
                    return userRepository;
                }
            }
    
            #endregion
    
            public void Save()
            {
                context.SaveChanges();
            }
    
            private bool disposed = false;
    
            protected virtual void Dispose(bool disposing)
            {
                if (!this.disposed)
                {
                    if (disposing)
                    {
                        context.Dispose();
                    }
                }
                this.disposed = true;
            }
    
            public void Dispose()
            {
                Dispose(true);
                GC.SuppressFinalize(this);
            }
        }
