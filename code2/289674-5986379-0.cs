    public IEnumerable<Review.Project> GetProjectsByUser(int userID)
    {
        var user = _context.Users.Where(u => u.UserID == userID).Single();
        //Now I am sure that user is not null
        return user.Projects;
    }
