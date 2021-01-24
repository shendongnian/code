       private IHostingEnvironment _env;
           var webRoot = _env.WebRootPath;
               var file = System.IO.Path.Combine(webRoot, "table.txt");
     [HttpPost, ValidateAntiForgeryToken]
        public IActionResult GetMailboxRules(MailboxRulesModel mailbox)
        {
        
            string currentuser = HttpContext.User.FindFirst("preferred_username")?.Value;
            string guid = Guid.NewGuid().ToString();
            using (DataTable results = Mail.GetMailboxRules(mailbox.EmailAddress, guid, currentuser))
            {
                List<string> return_list = new List<string>
                {
                    UtilityFunctions.ConvertDataTableToHTML(results, guid),
                    guid
                };
              using(TextWriter tw = new StreamWriter(file))
              {
              foreach (string s in return_list)
               tw.WriteLine(s);  
              }
                return {Your action method without parameter}
            }
        }
