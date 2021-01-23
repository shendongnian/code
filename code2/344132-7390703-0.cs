    public interface IAddRelatedItemRequest<T, U>
    {
        T Key { get; set; }
        IList<U> RelatedKey { get; set; }
    } 
