        protected void Page_Load(object sender, EventArgs e)
        {
    
            // Capture the post to this page
            IDictionary<string, string> variables = new Dictionary<string, string>();
    
            variables.Add("test", Request.Form["test"]); // collect all variables after checking they exist
        }
    
        public void RewriteContent(IDictionary<string, string> variables)
        {
            string formContent = @"
    <html>
        <head>
            <title>My Form</title>
        </head>
        <body>
            <form action='' method=''>";
    
            foreach (KeyValuePair<string, string> keyVal in variables)
            {
                formContent += @"<input type='" + keyVal.Key + "' value='" + keyVal.Value + "' />";
            }
            
        formContent += @"
            </form>
        </body>
    </html>"; // Add either an auto post in a javascript or an explicit submit button
    
            Response.Clear();
            Response.Write(formContent);
            Response.Flush();
            Response.End();
        }
