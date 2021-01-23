     // browser is the web browser control
     HtmlElementCollection col = browser.Document.GetElementsByTagName("div");
                foreach (HtmlElement helemnt in col)
                {
                    if (helemnt.InnerText !=null && helemnt.InnerText=="something") 
                    {
                       
                        helemnt.InvokeMember("Click");
                      
                           break; // break the loop
                       
                    }
                   
    
                   
                }
