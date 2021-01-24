static void Main(string[] args)
{
    MainAsync(args).GetAwaiter().GetResult();
}
static async Task MainAsync(string[] args)
{
    // Run your async code here
}
If you use C# 7.1, you can make your `Main`-method async (`static async Task Main(string[] args)`) and from there you can call your async code directly.
static async Task Main(string[] args)
{
    // Run your async code here
}
