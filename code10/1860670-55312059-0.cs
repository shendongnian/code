    class MultipleAsync
    {
        public async Task StartMultiple()
        {
            await CreateMultipleTasksAsync();
        }
        public static async Task CreateMultipleTasksAsync()
        {
            HttpClient client = new HttpClient() { MaxResponseContentBufferSize = 1000000 };
            Task<int> download1 = ProcessUrlAsync("https://msdn.microsoft.com", client);
            Task<int> download2 = ProcessUrlAsync("https://msdn.microsoft.com/library/67w7t67f.aspx", client);
            int length1 = await download1;
            int length2 = await download2;
            Console.WriteLine("Sum is {0}", length1 + length2);
        }
        public static async Task<int> ProcessUrlAsync(string url, HttpClient client)
        {
            Console.WriteLine("I am here to process {0}", url);
            var byteArray = await client.GetByteArrayAsync(url);
            Console.WriteLine("processing is completed {0}", url);
            return byteArray.Length;
        }
    }
