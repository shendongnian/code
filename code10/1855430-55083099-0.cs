    class Program
    {
        public static void Main()
        {
            string input = "GET /?code=CODE_I_NEED_APPEARS_HERE& HTTP/1.1 Host: localhost:8321 Connection: keep-alive Cache-Control: max-age=0 Upgrade-Insecure-Requests: 1 User-Agent: Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/72.0.3626.121 Safari/537.36 Accept: text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,/;q=0.8 Accept-Encoding: gzip, deflate, br Accept-Language: en-US,en;q=0.9";
            string output = GetCode(input);
            Console.WriteLine(output);
            Console.ReadLine();
        }
        private static readonly Regex Pattern = new Regex(@"code=([^&\s]+)", RegexOptions.Compiled);
        public static string GetCode(string input)
        {
            var value = Pattern.Match(input);
            return value.Groups[1].Value;
        }
    }
