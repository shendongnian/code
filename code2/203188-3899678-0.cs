    class Program
    {
        static void Main()
        {
            var secret = "secret";
            var data = "data";
            var hmac = new HMACSHA1(Encoding.UTF8.GetBytes(secret));
            var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(data));
        }
    }
