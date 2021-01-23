    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Net;
    using System.Threading;
    
    namespace UrlValidation
    {
        public class UrlValidator
        {
            internal static readonly Hashtable URLVerifications = new Hashtable();
            internal readonly List<ManualResetEvent> Handles = new List<ManualResetEvent>();
    
            internal void ValidateUrls()
            {
                var urlsToValidate = new[] { "http://www.ok12376876.com", "http//:www.ok.com", "http://www.ok.com", "http://cnn.com" };
                URLVerifications.Clear();
                foreach (var url in urlsToValidate)
                    CheckUrl(url);
                if (Handles.Count > 0)
                    WaitHandle.WaitAll(Handles.ToArray());
    
                foreach (DictionaryEntry verification in URLVerifications)
                    Console.WriteLine(verification.Value);
            }
    
            internal class RequestState
            {
                public WebRequest Request;
                public WebResponse Response;
                public ManualResetEvent Handle;
            }
    
            private void CheckUrl(string url)
            {
                var hashCode = url.GetHashCode();
                var evt = new ManualResetEvent(false);
                Handles.Add(evt);
    
                if (!Uri.IsWellFormedUriString(url, UriKind.Absolute))
                {
                    URLVerifications[hashCode] = "Invalid URL.";
                    evt.Set();
                    return;
                }
    
                if (!URLVerifications.ContainsKey(hashCode))
                    URLVerifications.Add(hashCode, null);
                // Create a new webrequest to the mentioned URL.   
                var wreq = WebRequest.Create(url);
                wreq.Timeout = 5000; // 5 seconds timeout per thread (ignored for async calls)
                var state = new RequestState{ Request = wreq, Handle = evt };
                // Start the Asynchronous call for response.
                var asyncResult = wreq.BeginGetResponse(RespCallback, state);
                ThreadPool.RegisterWaitForSingleObject(asyncResult.AsyncWaitHandle, TimeoutCallback, state, 5000, true);
            }
    
            private static void TimeoutCallback(object state, bool timedOut)
            {
                var reqState = (RequestState)state;
                if (timedOut)
                {
                    var hashCode = reqState.Request.RequestUri.OriginalString.GetHashCode();
                    URLVerifications[hashCode] = "Request timed out.";
                    if (reqState.Request != null)
                        reqState.Request.Abort();
                }
            }
    
            private static void RespCallback(IAsyncResult asynchronousResult)
            {
                ManualResetEvent evt = null;
                int hashCode = 0;
                try
                {
                    var reqState = (RequestState)asynchronousResult.AsyncState;
                    hashCode = reqState.Request.RequestUri.OriginalString.GetHashCode();
                    evt = reqState.Handle;
                    reqState.Response = reqState.Request.EndGetResponse(asynchronousResult);
                    var resp = ((HttpWebResponse)reqState.Response).StatusCode;
                    URLVerifications[hashCode] = resp.ToString();
                }
                catch (WebException e)
                {
                    if (hashCode != 0 && string.IsNullOrEmpty((string)URLVerifications[hashCode]))
                        URLVerifications[hashCode] = e.Response == null ? e.Status.ToString() : (int)((HttpWebResponse)e.Response).StatusCode + ": " + ((HttpWebResponse)e.Response).StatusCode;
                }
                finally
                {
                    if (evt != null)
                        evt.Set();
                }
            }
        }
    }
