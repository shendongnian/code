            void Load()
            {
                string html = DownloadHtml( "http://guyism.com/humor/mathematical-equations-that-explain-men.html" );
    
                MatchCollection matches = Regex.Matches( html, @"(<div class=""blog-post-inside"">.*?<center>---</center>)", RegexOptions.Singleline );    
                    
                webBrowser.ScriptErrorsSuppressed = true;
                webBrowser.DocumentText = matches[ 0 ].Groups[ 1 ].Value;
            }
    
            string DownloadHtml( string url )
            {
                using ( var client = new WebClient() )
                {
                    using ( var reader = new StreamReader( client.OpenRead( url ) ) )
                    {
                        return reader.ReadToEnd();
                    }
                }
            }
