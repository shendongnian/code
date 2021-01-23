    public IList<string> GetMovieCategories() 
    {
        using (ISession session = NHibernateSessionBuilder.OpenSession()) 
        {
            return session.CreateCriteria(typeof(Movie)).SetProjection(Projections.Property("Category")).List<string>();
        }
    }
