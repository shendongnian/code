    public interface IBlogRepository
    {
        ISession Session { set; }
    }
    
    class BlogRepository : IBlogRepository
    {
       private ISession m_session;
    
       ISession Session
       {
          set { m_session = value; }
       }
    }
