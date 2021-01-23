    public sealed partial class CommitPartial
    {
        public CommitID ID { get; private set; }
        public TreeID TreeID { get; private set; }
        public string Committer { get; private set; }
        public DateTimeOffset DateCommitted { get; private set; }
        public string Message { get; private set; }
        public CommitPartial(Builder b)
        {
            this.ID = b.ID;
            this.TreeID = b.TreeID;
            this.Committer = b.Committer;
            this.DateCommitted = b.DateCommitted;
            this.Message = b.Message;
        }
        public sealed class Builder
        {
            public CommitID ID { get; set; }
            public TreeID TreeID { get; set; }
            public string Committer { get; set; }
            public DateTimeOffset DateCommitted { get; set; }
            public string Message { get; set; }
            public Builder() { }
            public Builder(CommitPartial imm)
            {
                this.ID = imm.ID;
                this.TreeID = imm.TreeID;
                this.Committer = imm.Committer;
                this.DateCommitted = imm.DateCommitted;
                this.Message = imm.Message;
            }
            public Builder(
                CommitID pID
               ,TreeID pTreeID
               ,string pCommitter
               ,DateTimeOffset pDateCommitted
               ,string pMessage
            )
            {
                this.ID = pID;
                this.TreeID = pTreeID;
                this.Committer = pCommitter;
                this.DateCommitted = pDateCommitted;
                this.Message = pMessage;
            }
        }
        public static implicit operator CommitPartial(Builder b)
        {
            return new CommitPartial(b);
        }
    }
