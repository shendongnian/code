public class TrnApi<TEnum> : ITrnApi<TEnum> where TEnum : struct, Enum
{
	private readonly HttpClient _http;
	public IRTrainApi(HttpClient http, TEnum company)
	{
		_http = http;
		_http.BaseAddress = company.ToBaseUrl().ToUri();
        /* ... */
	}
}
