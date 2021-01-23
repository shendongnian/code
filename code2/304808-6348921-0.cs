        using (new OperationContextScope(service1.InnerChannel))
        {
            try
            {
                result = service1.GetData("5");
            }
            catch (System.Exception e)
            {
                string msg = e.ToString();
            }
            HttpResponseMessageProperty response = (HttpResponseMessageProperty)
                OperationContext.Current.IncomingMessageProperties[HttpResponseMessageProperty.Name];
        }
