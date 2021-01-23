    public class ForumPost : TableServiceEntity {
      public ForumPost(ForumThread ParentThread, bool IsFirstPost) 
        : base("partitionkey", 
            RowKeyStrategyFactory.Create().ResolveRowKey(IsFirstPost)) {
      }
    }
