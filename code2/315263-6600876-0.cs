    public class PostSummary
    {
        public Post Post {get;set;}
        public int AnswerCount {get;set;}
    }
    public IEnumerable<PostSummary> GetPostSummariesByUserAndRange(int userId, DateTime start, DateTime end)
    {
        using (var context = new MyEntities())
        {
            return context.Posts
                   .Where(p => p.UserId == userId)
                   .Where(p => p.TimeStamp < start && p.TimeStamp > end)
                   .Select(new PostSummary{Post = p, AnswerCount = p.Answers.Count()})
                   .ToList();
        }
    }
