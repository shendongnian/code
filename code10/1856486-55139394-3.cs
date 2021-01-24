    class RepositoryEntity<TSource> : IId, IRepositoryEntity
          where TSource : IDbItem
    {
         public TSource DbItem {get; set;}
         // Interface IId
         public int Id => this.DbItem.Id;
         // Interface IRepositoryEntity
         public bool IsObsolete => this.DbItem.ObsoleteDate != null;
         public void MarkObsolete()
         {
             this.DbItem.ObsoleteDate = DateTime.UtcNow;
         }
    }
