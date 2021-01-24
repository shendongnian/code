    [JsonConverter(typeof(FavoriveProductConverter))]
    public class FavoriteProductResponseModel : BaseResponse
    {
        public List<FavoriteProduct> FavoriteProducts { get; set; }
    }
