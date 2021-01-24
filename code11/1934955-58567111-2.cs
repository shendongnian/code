    public class ReceivedMessageEntityBinder : IModelBinder
        {
            public Task BindModelAsync(ModelBindingContext bindingContext)
            {
                if (bindingContext == null)
                {
                    throw new ArgumentNullException(nameof(bindingContext));
                }
    
                var request = bindingContext.HttpContext.Request;
    
                var firstKey = request.Form.Keys.First();
                StringValues formValue = "";
    
                request.Form.TryGetValue(firstKey, out formValue);
    
                var requestBody = firstKey + "=" + formValue;
                
                bindingContext.Result = ModelBindingResult.Success(FromXmlString(requestBody));
    
                return Task.CompletedTask;  
            }
    
            private ReceivedMessage FromXmlString(string requestBody)
            {
                XElement request = XElement.Parse(requestBody);
    
                var receivedMessage = new ReceivedMessage();
    
                receivedMessage.RequestId = (string)
                                            (from el in request.Descendants("requestId")
                                             select el).First();
    
                receivedMessage.Msisdn = (string)
                                            (from el in request.Descendants("msisdn")
                                             select el).First();
    
    
                receivedMessage.Timestamp = DateTime.Parse(
                                            (string)
                                            (from el in request.Descendants("timeStamp")
                                             select el).First());
    
    
                receivedMessage.Keyword = (string)
                                            (from el in request.Descendants("keyword")
                                             select el).First();
    
    
                IEnumerable<XElement> dataSet = from el in request.Descendants("param")
                                                select el;
    
                foreach (var param in dataSet)
                {
                    var firstNode = param.Descendants().First();
    
                    switch (firstNode.Value)
                    {
                        case "UserData":
                            receivedMessage.UserData = (firstNode.NextNode as XElement).Value;
                            break;
    
                        case "DA":
                            receivedMessage.Da = (firstNode.NextNode as XElement).Value;
                            break;
                    }
                }
    
                return receivedMessage;
            }
        }
