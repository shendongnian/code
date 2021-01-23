    public class Member
    {
        public int MemberID { get; set; }
    
        public string FirstName { get; set; }
        public string LastName { get; set; }
    
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<MemberCommentView> MemberComments { get; set; }
    }
    
    public class Comment
    {
        public int CommentID { get; set; }
        public string Message { get; set; }
    
        public virtual ICollection<Member> Members { get; set; }
        public virtual ICollection<MemberCommentView> MemberComments { get; set; }
    }
    
    public class MemberCommentView
    {
        public int MemberID { get; set; }
        public int CommentID { get; set; }
        public int Something { get; set; }
        public string SomethingElse { get; set; }
        public virtual Member Member { get; set; }
        public virtual Comment Comment { get; set; }
    }
