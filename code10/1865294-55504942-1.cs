    [Post]
    public async Task<JsonResult> AddMovieReview(int movieId, string comment, int rating)
    {
       // validate movie exists, and rating is valid, i.e. 1-5
       // create new Review entity using comment and rating.
       // load movie from context using movie ID.
       // add review to the movie.
       // save changes.
       // return a view model with a result (success/failure) and perhaps the new avg. rating for the movie.
    }
