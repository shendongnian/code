    public class CommentableItem {
        ICollection<Comment> Comments {get;set;}
    }
    public class Comment {
        CommentableItem CommentableItem {get;set;}
    }
    public class AnalysedMarket : CommentableItem {
    }
