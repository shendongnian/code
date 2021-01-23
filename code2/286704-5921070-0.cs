    public string BodyXamlWithOutHyperLink
            {
                get
                {
                    const string RegExPattern1 = @"<Hyperlink \S*"">";
                    const string RegExPattern2 = @"</Hyperlink>";
    
                    string body = this.BodyXaml;
    
                    if (string.IsNullOrEmpty(body))
                    {
                        return string.Empty;
                    }
    
                    Regex bodyRegEx = new Regex(RegExPattern1);
                    body = bodyRegEx.Replace(body, "<Bold>");
                    bodylRegEx = new Regex(RegExPattern2);
                    body= bodyRegEx.Replace(mail, "</Bold>");
    
                    return body;
                }
    
                set
                {
                   // can be ignored, we are read-only anyway
                }
            }
