        private void WebBrowser_Navigated(object sender, NavigationEventArgs e)
        {
           
            var doc = (WebBrowser.Document as HTMLDocument);
            if (doc != null)
            {
                var element = doc.getElementById("button id"); //Id of the input element
                if (element != null)
                { 
                    element.click();
                }
                
            }
             
        }
