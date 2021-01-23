    interface IKeyResolver<T, TKey>
    {
      TKey GetKey(T item);
    }
    public interface IAddRelatedItemRequest<TParentKey, TChildKey>
    {
      TParentKey Key { get;set; }
      List<TChildKey> RelatedKey { get;set; }
    }
    // assume categories have an int key
    class CategoryKeyResolver : IKeyResolver<int>
    {
      int GetKey(Category c) { return c.CategoryId; }
    }
    // assume articles use a GUID
    class ArticleKeyResolver : IKeyResolver<Guid>
    {
      Guid GetKey(Article a) { return a.ArticleId;
    }
