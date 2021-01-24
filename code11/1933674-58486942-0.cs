    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            SaveReportToDisk("http://localhost:13933/reports/sqlversioninfo", "CSV (comma delimited)", "C:\\temp\\reportDump.csv");
        }
        /// <summary>
        /// Automate clicking on the 'Save As' drop down menu in a report viewer control embedded at the specified URL
        /// </summary>
        /// <param name="sourceURL">URL that the report viewer control is hosted on</param>
        /// <param name="linkTitle">Title of the export option that you want to automate</param>
        /// <param name="savepath">The local path to save to exported report to</param>
        static void SaveReportToDisk(string sourceURL, string linkTitle, string savepath)
        {
            WebBrowser wb = new WebBrowser();
            wb.ScrollBarsEnabled = false;
            wb.ScriptErrorsSuppressed = true;
            wb.Navigate(sourceURL);
            //wait for the page to load
            while (wb.ReadyState != WebBrowserReadyState.Complete) { Application.DoEvents(); }
            // We want to find the Link that is the export to CSV menu item and click it
            // this is the first link on the page that has a title='CSV', modify this search if your link is different.
            // TODO: modify this selection mechanism to suit your needs, the following is very crude
            var exportLink = wb.Document.GetElementsByTagName("a")
                                        .OfType<HtmlElement>()
                                        .FirstOrDefault(x => (x.GetAttribute("title")?.Equals(linkTitle, StringComparison.OrdinalIgnoreCase)).GetValueOrDefault());
            if (exportLink == null)
                throw new NotSupportedException("Url did not resolve to a valid Report Viewer web Document");
            bool fileDownloaded = false;
            // listen for new window, using the COM wrapper so we can capture the url
            (wb.ActiveXInstance as SHDocVw.WebBrowser).NewWindow3 +=
                (ref object ppDisp, ref bool Cancel, uint dwFlags, string bstrUrlContext, string bstrUrl) =>
                {
                    Cancel = true; //should block the default browser from opening the link in a new window
                    Task.Run(async () =>
                    {
                        await DownloadLinkAsync(bstrUrl, savepath);
                        fileDownloaded = true;
                    }).Wait();
                };
            // execute the link
            exportLink.InvokeMember("click");
            //wait for the page to refresh
            while (!fileDownloaded) { Application.DoEvents(); }
        }
        private static async Task DownloadLinkAsync(string documentLinkUrl, string savePath)
        {
            var documentLinkUri = new Uri(documentLinkUrl);
            var cookieString = GetGlobalCookies(documentLinkUri.AbsoluteUri);
            var cookieContainer = new CookieContainer();
            using (var handler = new HttpClientHandler() { CookieContainer = cookieContainer })
            using (var client = new HttpClient(handler) { BaseAddress = documentLinkUri })
            {
                cookieContainer.SetCookies(documentLinkUri, cookieString);
                var response = await client.GetAsync(documentLinkUrl);
                if (response.IsSuccessStatusCode)
                {
                    var stream = await response.Content.ReadAsStreamAsync();
                    // Response can be saved from Stream
                    using (Stream output = File.OpenWrite(savePath))
                    {
                        stream.CopyTo(output);
                    }
                }
            }
        }
        // from Erika Chinchio which can be found in the excellent article provided by @Pedro Leonardo (available here: http://www.codeproject.com/Tips/659004/Download-of-file-with-open-save-dialog-box),
        [System.Runtime.InteropServices.DllImport("wininet.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto, SetLastError = true)]
        static extern bool InternetGetCookieEx(string pchURL, string pchCookieName,
    System.Text.StringBuilder pchCookieData, ref uint pcchCookieData, int dwFlags, IntPtr lpReserved);
        const int INTERNET_COOKIE_HTTPONLY = 0x00002000;
        private static string GetGlobalCookies(string uri)
        {
            uint uiDataSize = 2048;
            var sbCookieData = new System.Text.StringBuilder((int)uiDataSize);
            if (InternetGetCookieEx(uri, null, sbCookieData, ref uiDataSize,
                    INTERNET_COOKIE_HTTPONLY, IntPtr.Zero)
                &&
                sbCookieData.Length > 0)
            {
                return sbCookieData.ToString().Replace(";", ",");
            }
            return null;
        }
    }
