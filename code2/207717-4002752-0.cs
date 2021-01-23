    using System;
    using System.Linq;
    using System.Diagnostics;
    
    namespace UriTest
    {
        class Program
        {
            static bool IsAllowed(string uri, string[] allowedHosts)
            {
                UriBuilder builder = new UriBuilder(uri);
                return allowedHosts.Contains(builder.Host, StringComparer.OrdinalIgnoreCase);
            }
    
            static void Main(string[] args)
            {
                string[] allowedHosts =
                {
                    "google.com",
                    "yahoo.com",
                    "espn.com"
                };
    
                // All true
                Debug.Assert(
                    IsAllowed("google.com", allowedHosts) &&
                    IsAllowed("google.com/bar", allowedHosts) &&
                    IsAllowed("http://google.com/", allowedHosts) &&
                    IsAllowed("http://google.com/foo/bar", allowedHosts) &&
                    IsAllowed("http://google.com/foo/page.html?bar=baz", allowedHosts)
                );
    
                // All false
                Debug.Assert(
                    !IsAllowed("foo.com", allowedHosts) &&
                    !IsAllowed("foo.com/bar", allowedHosts) &&
                    !IsAllowed("http://foo.com/", allowedHosts) &&
                    !IsAllowed("http://foo.com/foo/bar", allowedHosts) &&
                    !IsAllowed("http://foo.com/foo/page.html?bar=baz", allowedHosts)
                );
            }
        }
    }
