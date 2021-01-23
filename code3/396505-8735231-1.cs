    void IClientMessageInspector.AfterReceiveReply(ref Message reply, Object correlationState)
    {
        var prop = 
            reply.Properties[HttpResponseMessageProperty.Name] as HttpResponseMessageProperty;
        if (prop != null)
        {
            // get the content type headers
            var contentType = prop.Headers["Content-Type"];
        }
    }
