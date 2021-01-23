    public class Export : IHttpHandler, IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            object json = null;
            byte[] input = null;
            JavaScriptSerializer javascriptSerializer = null;
            StringBuilder sb = null;
            List<object> elementList = null;
            List<string> headerList = null;
            try
            {
                input = readToEnd(context.Request.InputStream);
                sb = new StringBuilder();
                javascriptSerializer = new JavaScriptSerializer();
                foreach (byte chr in input)
                {
                    sb.Append((char)chr);
                }
                json = javascriptSerializer.DeserializeObject(sb.ToString());
                elementList = new List<object>();
                headerList = new List<string>();
                var dictionary = json.toType(new Dictionary<string, object>());
                foreach (KeyValuePair<string, object> keyValuePair in dictionary)
                {
                    switch (keyValuePair.Key)
                    {
                        case "elements":
                        case "ELEMENTS":
                            {
                                object[] elements = (object[])keyValuePair.Value;
                                foreach (object element in elements)
                                {
                                    elementList.Add(element);
                                }
                                break;
                            }
                        case "headers":
                        case "HEADERS":
                            {
                                object[] headers = (object[])keyValuePair.Value;
                                foreach (object header in headers)
                                {
                                    headerList.Add((string)header);
                                }
                                break;
                            }
                    }
                }
                ((StringBuilder) context.Session["ExportCSV"]).Append(writeBodyInfo(elementList, headerList));
                ((StringBuilder) context.Session["ExportCSV"]).Append(writeHeadersInfo(headerList));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
