var additionalBindingData = parsed.Children<JProperty>()
	.Where(p => p.Value != null && (p.Value.Type != JTokenType.Array))
It seems like the only way to achieve this is with a [workaround](https://github.com/Azure/azure-functions-host/issues/3370#issuecomment-424779907).
Another approach would be to use the `ReadAsAsync<T>` extension method.
namespace StackOverflow.AccountsQuestion
{
    public sealed class AccountFunction
    {
        private readonly ILogger m_logger;
        public AccountFunction(ILoggerFactory loggerFactory)
        {
            m_logger = loggerFactory.CreateLogger<AccountFunction>();
        }
        [FunctionName("AccountFunction")]
        public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "v1/accounts")] HttpRequestMessage request)
        {
            m_logger.LogInformation("C# HTTP trigger function processed a request.");
            var accounts = await request.Content.ReadAsAsync<List<Account>>();
            return new OkObjectResult(accounts);
        }
    }
    public class Account
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
