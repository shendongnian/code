    public static void ComplexSort(IQueryable<string> Pages)
    {
        Pages.OrderByDescending(p =>
            {
                int rating = 99;//(from r in db.rating select r). sum();
                int comments = 33;//query database for comments;
                double timedecayfactor = Math.Exp(88);
                return (rating + comments) * timedecayfactor;
            });
    }
