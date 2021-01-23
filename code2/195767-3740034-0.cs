    public class ForumPost : TableServiceEntity
    {
        public ForumPost(ForumThread ParentThread, bool IsFirstPost)
            : base(ParentThread, GetID(IsFirstPost))
        {
        }
    
        static string GetID(bool IsFirstPost)
        {
            return IsFirstPost ? "00000" : "11111";
        }
    }
