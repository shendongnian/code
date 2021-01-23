    public IList<string> GetMovieCategories() 
    {
        using (ISession session = NHibernateSessionBuilder.OpenSession()) 
        {
            return session.QueryOver<Movie>()
                   .Select(c => c.Category)
                   .List<string>();
        }
    }
