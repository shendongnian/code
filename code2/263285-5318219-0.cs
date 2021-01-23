    public class BrowserLocation
    {
        /// <summary>
        /// Structure to hold the details regarding a browed location
        /// </summary>
        public struct URLDetails
        {
            /// <summary>
            /// URL (location)
            /// </summary>
            public String URL;
            /// <summary>
            /// Document title
            /// </summary>
            public String Title;
        }
        #region Internet Explorer
        // requires the following DLL added as a reference:
        // C:\Windows\System32\shdocvw.dll
        /// <summary>
        /// Retrieve the current open URLs in Internet Explorer
        /// </summary>
        /// <returns></returns>
        public static URLDetails[] InternetExplorer()
        {
            System.Collections.Generic.List<URLDetails> URLs = new System.Collections.Generic.List<URLDetails>();
            var shellWindows = new SHDocVw.ShellWindows();
            foreach (SHDocVw.InternetExplorer ie in shellWindows)
                URLs.Add(new URLDetails() { URL = ie.LocationURL, Title = ie.LocationName });
            return URLs.ToArray();
        }
        #endregion
        #region Firefox
        // This requires NDde
        // http://ndde.codeplex.com/
        public static URLDetails[] Firefox()
        {
            NDde.Client.DdeClient dde = new NDde.Client.DdeClient("Firefox", "WWW_GetWindowInfo");
            try
            {
                dde.Connect();
                String url = dde.Request("URL", Int32.MaxValue);
                dde.Disconnect();
                Int32 stop = url.IndexOf('"', 1);
                return new URLDetails[]{
                    new URLDetails()
                    {
                        URL = url.Substring(1, stop - 1),
                        Title = url.Substring(stop + 3, url.Length - stop - 8)
                    }
                };
            }
            catch (Exception)
            {
                return null;
            }
        }
        #endregion
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Internet Explorer: ");
            (new List<BrowserLocation.URLDetails>(BrowserLocation.InternetExplorer())).ForEach(u =>
            {
                Console.WriteLine("[{0}]\r\n{1}\r\n", u.Title, u.URL);
            });
            Console.WriteLine();
            Console.WriteLine("Firefox:");
            (new List<BrowserLocation.URLDetails>(BrowserLocation.Firefox())).ForEach(u =>
            {
                Console.WriteLine("[{0}]\r\n{1}\r\n", u.Title, u.URL);
            });
            Console.WriteLine();
        }
    }
