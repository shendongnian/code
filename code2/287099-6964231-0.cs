     string html = "This is sample <p id=\"short\"> the value of short </p> <p id=\"medium\"> the value of medium </p> <p id=\"large\"> the value of large</p>";
                string id = null;
                NameValueCollection output = new NameValueCollection();
                string[] pIds = new string[3] { "short", "medium", "large" };
                HtmlDocument doc = new HtmlDocument();
                doc.LoadHtml(html);
                int c = 0;
                int len = pIds.Length;
                while (c < len)
                {
                    id = pIds[c];
                    output.Add(id, doc.GetElementbyId(id).InnerHtml);
                    c++;
                }
           //In key of output variable, is equivalent to value of paragraph. example:
            Console.WriteLine(output["short"].ToString()); 
         
