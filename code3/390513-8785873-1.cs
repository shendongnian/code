    public void ProvideFault(Exception error, MessageVersion version, ref Message fault)
            {
                if (error.Message.Contains("IsEmpty = true"))
                {
                    fault = Message.CreateMessage(version, "");
                    var jsonFormatting = new WebBodyFormatMessageProperty(WebContentFormat.Json);
                    fault.Properties.Add(WebBodyFormatMessageProperty.Name, jsonFormatting);
                    var httpResponse = new HttpResponseMessageProperty
                                           {
                        StatusCode = System.Net.HttpStatusCode.OK,
                        StatusDescription = "OK"
                    };
                    fault.Properties.Add(HttpResponseMessageProperty.Name, httpResponse);
                }
                else
                {
                    fault = GetJsonFaultMessage(version, error);
    
                    var jsonFormatting = new WebBodyFormatMessageProperty(WebContentFormat.Json);
                    fault.Properties.Add(WebBodyFormatMessageProperty.Name, jsonFormatting);
                    var httpResponse = new HttpResponseMessageProperty
                                           {
                        StatusCode = System.Net.HttpStatusCode.BadRequest,
                        StatusDescription = "Bad Request"
                    };
                    fault.Properties.Add(HttpResponseMessageProperty.Name, httpResponse);
                }
            }
