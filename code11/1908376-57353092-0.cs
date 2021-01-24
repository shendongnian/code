      IService service = factory.CreateChannel();
                using (OperationContextScope scope = new OperationContextScope((IContextChannel)service))
                {
                    WebOperationContext.Current.OutgoingRequest.ContentType = "text/xml;charset=utf-8";
                    service.GetData();
                }
