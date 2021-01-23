    public void ProcessRequest(HttpContext context)
            {
                RequestTarget target = RequestTarget.ParseFromQueryString(context.Request.QueryString);
                Guid requestId = new Guid(context.Request.QueryString["requestId"]);
                string itemName = HttpUtility.UrlDecode(context.Request.QueryString["itemName"]);
                if (target != null &&
                    !requestId.Equals(Guid.Empty) &&
                    !string.IsNullOrEmpty(itemName))
                {
                    HttpResponse response = context.Response;
                    response.Buffer = false;
                    response.Clear();
                    response.AddHeader("Content-Disposition", "attachment;filename=\"" + itemName + "\"");
                    response.ContentType = "application/octet-stream";
                    int length = 100000, i = 0;
                    byte[] fileBytes;
                    do
                    {
                        fileBytes = WS.ReadFile(requestId, target, i * length, length);
                        i++;
                        response.OutputStream.Write(fileBytes, 0, fileBytes.Length);
                        response.Flush();
                    }
                    while (fileBytes != null && fileBytes.Length == length);
                }
            }
