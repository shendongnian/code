    using System.IO;
    using System.Threading.Tasks;
    
    namespace TestApp
    {
        interface IBlackBox // interface for both sync and async execution
        {
            Task<string> PullText();
        }
    
        sealed class MyAsyncBlackBox : IBlackBox
        {
            public async Task<string> PullText()
            {
                using (var reader = File.OpenText("Words.txt"))
                {
                    return await reader.ReadToEndAsync();
                }
            }
        }
    
        sealed class MyCachedBlackBox : IBlackBox
        {
            public Task<string> PullText() // notice no 'async' keyword
            {
                return Task.FromResult("hello world");
            }
        }
    }
