     public class Comment 
     {
       ...
       public string ParentCommentId {get;set;}
     }
    
     public class Article
     {
       ...
       public List<Comment> Comments {get;set;}
     }
