    public class ItemResponse<T> : Response
    {
    /// <summary>
    /// constructor to set private properties Item and Status
    /// </summary>
    /// <param name="item"></param>
    /// <param name="status"></param>
    public ItemResponse(T item, ResponseStatusEnum status) : base(status)
    {
        Item = item;
    }
    public ItemResponse()
    {
    }
    public ItemResponse(ResponseStatusEnum status, System.Collections.Generic.List<ResponseError> errors) : base(status, errors)
    {
    }
    public T Item
    {
         get; set;
    }
}
