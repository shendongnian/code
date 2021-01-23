    namespace WebApplication4
    {
        public partial class WebForm1 : System.Web.UI.Page
        {
       
            protected void Page_Load(object sender, EventArgs e)
             {
           
              string VisitorsIPAddr = string.Empty;
              //Users IP Address.                
              if (HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] != null)
              {
                  //To get the IP address of the machine and not the proxy
                  VisitorsIPAddr =   HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].ToString();
              }
              else if (HttpContext.Current.Request.UserHostAddress.Length != 0)
              {
                  VisitorsIPAddr = HttpContext.Current.Request.UserHostAddress;`enter code here`
              }
    
              string res = "http://ipinfo.io/" + VisitorsIPAddr + "/city";
              string ipResponse = IPRequestHelper(res);
              
            }
    
            public string IPRequestHelper(string url)
            {
    
                string checkURL = url;
                HttpWebRequest objRequest = (HttpWebRequest)WebRequest.Create(url);
                HttpWebResponse objResponse = (HttpWebResponse)objRequest.GetResponse();
                StreamReader responseStream = new StreamReader(objResponse.GetResponseStream());
                string responseRead = responseStream.ReadToEnd();
                responseRead = responseRead.Replace("\n", String.Empty);
                responseStream.Close();
                responseStream.Dispose();
                return responseRead;
            }
    
          
        }
    }
