        static public void SetWebBrowserHtml(WebBrowser Browser, string HtmlText)
        {
            if (Browser != null)
            {
                if (string.IsNullOrWhiteSpace(HtmlText))
                {
                    // Putting a div inside body forces control to use div instead of P (paragraph)
                    // when the user presses the enter button
                    HtmlText = 
                            @"<html>
                        <head>
                        <meta http-equiv=""Content-Type"" content=""text/html; charset=UTF-8"" />
                        </head>
                          <div></div>
                        <body>
                        </body>
                        </html>";
                }
                if (Browser.Document == null)
                {
                    Browser.Navigate("about:blank");
                    //Wait for document to finish loading
                    while (Browser.ReadyState != WebBrowserReadyState.Complete)
                    {
                        Application.DoEvents();
                        System.Threading.Thread.Sleep(5);
                    }
                }
                // Write html code
                dynamic Doc = Browser.Document.DomDocument;
                Doc.open();
                Doc.write(HtmlText);
                Doc.close();
                // Add scripts here 
                /*  
                dynamic Doc = Document.DomDocument;
                dynamic Script = Doc.getElementById("MyScriptFunctions");
                if (Script == null)
                {
                    Script = Doc.createElement("script");
                    Script.id = "MyScriptFunctions";
                    Script.text = JavascriptFunctionsSourcecode;
                    Doc.appendChild(Script);
                }                 
                */
                // Enable contentEditable   
                /*  
                if (Browser.Document.Body != null)
                {
                    if (Browser.Version.Major >= 9)
                        Browser.Document.Body.SetAttribute("contentEditable", "true");
                }             
                 */
                // Attach event handlers
                // Browser.Document.AttachEventHandler("onkeyup", BrowserKeyUp);
                // Browser.Document.AttachEventHandler("onkeypress", BrowserKeyPress);
                // etc...
            }
        }        
