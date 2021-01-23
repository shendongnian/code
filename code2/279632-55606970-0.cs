    public class RemotePost
    {
        private Dictionary<string, string> Inputs = new Dictionary<string, string>();
        public string Url = "";
        public string Method = "post";
        public string FormName = "form1";
        public StringBuilder strPostString;
    
        public void Add(string name, string value)
        {
            Inputs.Add(name, value);
        }
        public void generatePostString()
        {
            strPostString = new StringBuilder();
    
            strPostString.Append("<html><head>");
            strPostString.Append("</head><body onload=\"document.form1.submit();\">");
            strPostString.Append("<form name=\"form1\" method=\"post\" action=\"" + Url + "\" >");
    
            foreach (KeyValuePair<string, string> oPar in Inputs)
                strPostString.Append(string.Format("<input name=\"{0}\" type=\"hidden\" value=\"{1}\">", oPar.Key, oPar.Value));
    
            strPostString.Append("</form>");
            strPostString.Append("</body></html>");
        }
        public void Post()
        {
            System.Web.HttpContext.Current.Response.Clear();
            System.Web.HttpContext.Current.Response.Write(strPostString.ToString());
            System.Web.HttpContext.Current.Response.End();
        }
    }
