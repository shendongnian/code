    public List<Comment> IQueryable2ToList(IQueryable<Comment> comments)
    {
        List<Comment> comments = comments.ToList()
        foreach (Comment c in comments) {
            c.UpVotes = 0 //get UpVotes
            c.DownVotes = 0 // get DownVotes
        }
        return comments;
    }
