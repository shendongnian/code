    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ConsoleApp1
    {
        class Program
        {
            static async Task Main()
            {
                var client = new HttpClient();
                using (var response = await client.GetAsync("https://example.com/index.html"))
                using (var stream = await response.Content.ReadAsStreamAsync())
                {
                    var buffer = new byte[200];
                    var count = await stream.ReadAsync(buffer, 0, buffer.Length);
                    var result = Encoding.UTF8.GetString(buffer);
                }
            }
        }
    }
