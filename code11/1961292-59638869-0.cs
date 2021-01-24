    using (new OperationContextScope((IClientChannel)service))
                {
                    //first method to add HTTP header.
                    //HttpRequestMessageProperty request = new HttpRequestMessageProperty();
                    //request.Headers["MyHttpheader"] = "myvalue";
                    //OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] = request;
                    //WebOperationContext is syntax sugar of wrapper above method.                OperationContext oc = OperationContext.Current;
                    WebOperationContext woc = new WebOperationContext(oc);
                    woc.OutgoingRequest.Headers.Add("myhttpheader", "myvalue");
                    //invocation, only valid in this request.
                    var result = service.GetResult();
                    Console.WriteLine(result);
                }
