     class Program
        {
    
            static string Extract(string s, string tag)
            {
                 var startTag = String.Format("id=\"{0}\" value=\"", tag);
                var eaPos = s.IndexOf(startTag) + startTag.Length ;
                var eaPosLast = s.IndexOf('"', eaPos);
                return s.Substring(eaPos, eaPosLast-eaPos);
            }
    
            static void Main(string[] args)
            {
            
                WebClient webClient = new WebClient();
    
                var firstResponse = webClient.DownloadString(@"http://www.mcxindia.com/sitepages/BhavCopyDateWise.aspx");
    
                var forms = new NameValueCollection();
                forms["__EVENTARGUMENT"] = "";
                forms["__VIEWSTATE"] = Extract(firstResponse, "__VIEWSTATE");
                forms["mTbdate"] = "12/22/2011";
                forms["__EVENTVALIDATION"] = Extract(firstResponse, "__EVENTVALIDATION");
                forms["mImgBtnGo.x"] = "10";
                forms["mImgBtnGo.y"] = "10";
                forms["ScriptManager1"] = "MupdPnl|mImgBtnGo"; 
                // forms["__EVENTTARGET"] = "btnLink_Excel";
                webClient.Headers.Set(HttpRequestHeader.ContentType, "application/x-www-form-urlencoded");
    
                String secondResponse = UTF8Encoding.UTF8.GetString(
                    webClient.UploadValues(@"http://www.mcxindia.com/sitepages/BhavCopyDateWise.aspx", "POST", forms)
                  );
    
                forms = new NameValueCollection();         
                forms["__EVENTARGUMENT"] = "";
                forms["__VIEWSTATE"] = Extract(secondResponse, "__VIEWSTATE");        
                forms["mTbdate"] = "12/22/2011";
                forms["__EVENTVALIDATION"] = Extract(secondResponse, "__EVENTVALIDATION");         
                // forms["mImgBtnGo"] = "?";         
                forms["__EVENTTARGET"] = "btnLink_Excel";          
                webClient.Headers.Set(HttpRequestHeader.ContentType, "application/x-www-form-urlencoded");          
                var responseData = webClient.UploadValues(@"http://www.mcxindia.com/sitepages/BhavCopyDateWise.aspx", "POST", forms);         
                System.IO.File.WriteAllBytes(@"c:\prj\11152011.csv", responseData);  	
                }
    
         }
