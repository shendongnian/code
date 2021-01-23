        public void ProcessRequest(HttpContext context)
         {
              string prefixText = context.Request.QueryString["q"]; 
              //do your thing here and return as a bar separated list
              StringBuilder sb = new StringBuilder();
              foreach(Results res in results )
                {
                    sb.Append(String.Format("{0}|{1}|{2}", +res.Val1, res.Val2, res.Val3));
                    sb.Append(Environment.NewLine);
                }
              context.Response.Write(sb.ToString());
         }
