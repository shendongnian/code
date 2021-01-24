    class Program
        {
            // Assume this is a normal synchronous operation
            static Result<int> GetMyLength(string text) => Result.Ok(text.Length);
    
            // Assume this a typical async operation, such as a web request
            static async Task<Result<int>> DuplicateThisAsync(int x) => await Task.FromResult(Result.Ok(x * 2));
    
            static async Task Main()
            {
                var tryResult = GetMyLength("Daan")
                if tryResult.Success // Something similar if .Success is not available
                {
                   tryResult = await DuplicateThisAsync(tryResult.Value));
                   Console.WriteLine(tryResult.Value);
                }
                Console.ReadLine();
            }
        }
