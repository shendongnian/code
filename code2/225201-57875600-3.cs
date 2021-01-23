c#
        public static async Task<string> FnDownloadStringWithoutWebRequest(string url)
        {
            using (var client = new HttpClient())
            {
                //Define Headers
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    //dynamic json = Newtonsoft.Json.JsonConvert.DeserializeObject(responseContent);
                    return responseContent;
                }
                Logger.DefaultLogger.LogError(LogLevel.NORMAL, "GoogleLoginManager.FnDownloadString", "error fetching string, code: " + response.StatusCode);
                return "";
            }
        }
This is however still slow with Managed HttpClient.
So **secondly,** in Visual Studio Community for Mac, right click on your Project in the Solution -> Options -> **set *HttpClient implementation* to NSUrlSession, instead of Managed**.
[Screenshot: Set HttpClient implementation to NSUrlSession instead of Managed][1]
Managed is not fully integrated into iOS, doesn't support TLS 1.2, and thus does not support the ATS standards set as default in iOS9+, see here:
https://docs.microsoft.com/en-us/xamarin/ios/app-fundamentals/ats
With both these changes, string downloads are always very fast (<<1s).
Without both of these changes, on every second or third try, downloadString took over a minute.
-----------
Just FYI, there's one more thing you could try, though it **shouldn't be necessary anymore**:
c#
            //var authgoogle = new OAuth2Authenticator(...);
            //authgoogle.Completed...
            if (authgoogle.IsUsingNativeUI)
            {
                // Step 2.1 Creating Login UI 
                // In order to access SFSafariViewController API the cast is neccessary
                SafariServices.SFSafariViewController c = null;
                c = (SafariServices.SFSafariViewController)ui_object;
                PresentViewController(c, true, null);
            }
            else
            {
                PresentViewController(ui_object, true, null);
            }
Though in my experience, you probably don't need the SafariController.
  [1]: https://i.stack.imgur.com/5cEkU.png
