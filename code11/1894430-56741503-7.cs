    public class BaseResponse<T>
    {
        public T Data { get; set; }
    }
    public class FavoriteProductResponseModel : BaseResponse<List<FavoriteProduct>>
    {
    }
