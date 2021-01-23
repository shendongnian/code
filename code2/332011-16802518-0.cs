    public class Member {
        public int MemberID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual ICollection<MemberComment> MemberComments { get; set; }
    }
    public class Comment {
        public int CommentID { get; set; }
        public string Message { get; set; }
        public virtual ICollection<MemberComment> MemberComments { get; set; }
    }
    public class MemberComment {
        public int MemberID { get; set; }
        public int CommentID { get; set; }
        // Note the changed type and name!
        public bool CreatedDate { get; set; }
        public MemberComment() {
            CreatedDate = DateTime.Now;
        }
    }
