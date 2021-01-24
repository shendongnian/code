	public class BaseResponse
	{
		public bool HasError { get; set; }
		public string Error { get; set; }
	}	
	public class CreateProductResponse : BaseResponse
	{
	 ---
	}
	public class CreateProductDetailResponse : CreateProductResponse
	{
	 ---
	}
