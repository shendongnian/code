    class Program
    {
        static void Main(string[] args)
        {
            var testCases = new[]
            {
                "www.domain.com.ac",
                "www.domain.ac",
                "domain.com.ac",
                "domain.ac",
                "localdomain",
                "localdomain.local"
            };
            foreach (string testCase in testCases)
            {
                Console.WriteLine("{0} => {1}", testCase, UriHelper.GetDomainFromUri(new Uri("http://" + testCase + "/")));
            }
            /* Produces the following results:
                www.domain.com.ac => domain.com.ac
                www.domain.ac => domain.ac
                domain.com.ac => domain.com.ac
                domain.ac => domain.ac
                localdomain => localdomain
                localdomain.local => localdomain.local
             */
        }
    }
    public static class UriHelper
    {
        private static HashSet<string> _tlds;
        static UriHelper()
        {
            _tlds = new HashSet<string>
            {
                "com.ac",
                "edu.ac",
                "gov.ac",
                "net.ac",
                "mil.ac",
                "org.ac",
                "ac"
                // Complete this list from http://publicsuffix.org/.
            };
        }
        public static string GetDomainFromUri(Uri uri)
        {
            return GetDomainFromHostName(uri.Host);
        }
        public static string GetDomainFromHostName(string hostName)
        {
            string[] hostNameParts = hostName.Split('.');
            if (hostNameParts.Length == 1)
                return hostNameParts[0];
            int matchingParts = FindMatchingParts(hostNameParts, 1);
            return GetPartOfHostName(hostNameParts, hostNameParts.Length - matchingParts);
        }
        private static int FindMatchingParts(string[] hostNameParts, int offset)
        {
            if (offset == hostNameParts.Length)
                return hostNameParts.Length;
            string domain = GetPartOfHostName(hostNameParts, offset);
            if (_tlds.Contains(domain.ToLowerInvariant()))
                return (hostNameParts.Length - offset) + 1;
            return FindMatchingParts(hostNameParts, offset + 1);
        }
        private static string GetPartOfHostName(string[] hostNameParts, int offset)
        {
            var sb = new StringBuilder();
            for (int i = offset; i < hostNameParts.Length; i++)
            {
                if (sb.Length > 0)
                    sb.Append('.');
                sb.Append(hostNameParts[i]);
            }
            string domain = sb.ToString();
            return domain;
        }
    }
