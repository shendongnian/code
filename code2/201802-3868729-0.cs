    [Flags]
    public enum PostAssociations
    {    
        None = 0x0,
        User = 0x1,
        Comments = 0x2,
        CommentsUser = User|Comments,
    }
