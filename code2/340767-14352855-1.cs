    string result = "";
                try
                {
                    using (StreamReader sr = new StreamReader(IOParams.ConfigPath +   "SUCCESSEMPTMP.HTML"))
                    {
                        result = sr.ReadToEnd();
                        result = result.Replace("<body/>", "<body>");
                        result = result.Replace("</body>", "<body>");
                        List<string> body = new List<string>(result.Split(new string[] { "<body>" }, StringSplitOptions.None));
                        if (body.Count > 2)
                        {
                            result = body[1];
                        }
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
    
                return result;
