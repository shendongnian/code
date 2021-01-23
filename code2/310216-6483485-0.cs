        using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Web;
    using System.Web.UI;
    
    public partial class TestPage : Page
    {
        private WebRequest _request;
        protected void Page_Load(object sender, EventArgs e)
        {
            string text;
            string url = Request["UrlToGet"];
            _request = (HttpWebRequest)
                WebRequest.Create(url);
            using (WebResponse response = _request.GetResponse())
            {
                using (StreamReader reader =
                    new StreamReader(response.GetResponseStream()))
                {
                    text = reader.ReadToEnd();
                }
            }
        }
    }
