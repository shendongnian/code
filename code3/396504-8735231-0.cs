    void IClientMessageInspector.AfterReceiveReply(ref Message reply, Object correlationState)
    {
        HttpResponseMessageProperty prop = 
            reply.Properties [HttpResponseMessageProperty.Name.ToString()] as HttpResponseMessageProperty;
        if (prop != null)
        {
            // get the content type headers
            var contentType = prop.Headers["Content-Type"];
        }
    }
