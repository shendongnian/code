    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Xml.Linq;
    
    namespace WebDomino
    {
    
        /// <summary>
        /// A stateful (authenticated) session with a Domino server.  Current version only supports
        /// forms based authentication, and does not permit bypassing authentication.
        /// </summary>
        public class DominoHttpSession
        {
            /// <summary>
            /// Username with which to authenticate to the Domino server, must be a legal web user name.
            /// </summary>
            public string UserName { set; get; }
    
            /// <summary>
            /// Web password of the authenticating account.
            /// </summary>
            public string Password { set; get; }
    
            /// <summary>
            /// The server on which the session will exist.  At this time, all connections must use
            /// the same server.  Untested but probably will work:  switching server name before establishing
            /// a connection, as long as the authentication cookies are shared.
            /// </summary>
            public string ServerHostName { set; get; }
    
            /// <summary>
            /// The session cookies.  Provided in case client code wants to analyze cookie content, but
            /// more likely only used internally to hold the authentication cookie from the server.
            /// </summary>
            public CookieContainer Cookies { get { return cookies; } }
    
            private CookieContainer cookies = new CookieContainer();
    
            /// <summary>
            /// Sends an HTTP GET to the server, expecting an XML response.   
            /// </summary>
            /// <param name="url">The full url to GET; proper syntax is the responsibility of the caller.</param>
            /// <returns>The XElement representing the returned XML text</returns>
            public XElement GetXml(string url)
            {
                return XElement.Parse(Get(url));
            }
    
            public string Get(string url)
            {
                var request = (HttpWebRequest)WebRequest.Create(url);
    
                request.CookieContainer = cookies;
                request.Method = "GET";
    
                using (var responseStream = request.GetResponse().GetResponseStream())
                using (var reader = new StreamReader(responseStream))
                {
                    var result = reader.ReadToEnd();
                    return result;                
                }                                
            }
    
            /// <summary>
            /// Must be called to establish the session with the server.
            /// </summary>
            public void Authenticate()
            {            
                ServicePointManager.Expect100Continue = false;
    
                var request = (HttpWebRequest)WebRequest.Create(String.Format("http://{0}//names.nsf?Login", ServerHostName));
                request.CookieContainer = cookies;
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                using (var requestStream = request.GetRequestStream())
                using (var writer = new StreamWriter(requestStream))
                {
                    writer.Write("Username={0}&Password={1}", UserName,Password);
                }
    
                using (var responseStream = request.GetResponse().GetResponseStream())
                using (var reader = new StreamReader(responseStream))
                {
                    var result = reader.ReadToEnd();  
                  
                    // Success is assumed here--in production code it should not be
                }                                           
            }
    
            public ViewReader GetViewReader(string dbPath, string viewName)
            {
                return new ViewReader(this)
                       {
                           DbPath = dbPath,
                           View = viewName
                       };
            }
    
        }
    
        
    }
