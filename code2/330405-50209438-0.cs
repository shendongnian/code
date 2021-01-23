                var curenturl = Request.Url.ToString();           
                if (Regex.IsMatch(curenturl, @"[A-Z]"))
                {
                    Response.Clear();
                    Response.Status = "301 Moved Permanently";
                    Response.StatusCode = 301;
                    Response.AddHeader("Location", curenturl.ToLower());
                    Response.End();
                }
