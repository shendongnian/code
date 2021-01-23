    class Program
    {
        static string secretKey = "Removed";
        static void Main(string[] args)
        {
            string policyStr = @"{""expiration"": ""2012-01-01T12:00:00.000Z"",""conditions"": [{""bucket"": ""<bucket>"" },{""acl"": ""public-read"" },[""eq"", ""$key"", ""<filename>""],[""starts-with"", ""$Content-Type"", ""image/""],]}";
            GetSig(policyStr);
        }
        static void GetSig(string policyStr)
        {
            string b64Policy = Convert.ToBase64String(Encoding.ASCII.GetBytes(policyStr));
            byte[] b64Key = Encoding.ASCII.GetBytes(secretKey);
            HMACSHA1 hmacSha1 = new HMACSHA1(b64Key);
            Console.WriteLine(policyStr);
            Console.WriteLine(b64Policy);
            Console.WriteLine();
            Console.WriteLine(
                Convert.ToBase64String(hmacSha1.ComputeHash(Encoding.ASCII.GetBytes(b64Policy))));
            Console.ReadKey();
        }
    }
