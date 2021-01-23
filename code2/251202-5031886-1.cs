    public class CommentPresentation { 
        public int    CommentID { get; set; }
        public string WittyInsight { get; set; }
        public int    UpVotes { get; set; }
        public int    DownVotes { get; set; }
        public int CurrentVotes()
        {
            return UpVotes - DownVotes;
        }
    }
    public IQueryable<CommentPresentation> ToPresentation(IQueryable<Comment> comments)
    {
        return from c in comments
               select new CommentPresentation
               {
                   CommentId = c.CommentId,
                   WittyInsight = c.WittyInsight,
                   UpVotes = 0,
                   DownVotes = 0
               };
    }
