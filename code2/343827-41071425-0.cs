        /// <summary>
        /// Try to set the content type as close to the user's preference as we can get.
        /// </summary>
        private void SetContentType()
        {
            if (WebOperationContext.Current == null)
            {
                throw new InvalidOperationException("There is no WebOperationContext. This class expects to operate within a WCF context.");
            }
            WebMessageFormat contentType = WebMessageFormat.Json;
            //first let's grab the default, if possible
            if (_serviceEndpoint.EndpointBehaviors.Contains(typeof (WebHttpBehavior)))
            {
                var behavior = (WebHttpBehavior)_serviceEndpoint.EndpointBehaviors[typeof (WebHttpBehavior)];
                contentType = behavior.DefaultOutgoingResponseFormat;
            }
            else if (_serviceEndpoint.EndpointBehaviors.Contains(typeof(WebHttpByteResponseBehavior)))
            {
                var behavior = (WebHttpByteResponseBehavior)_serviceEndpoint.EndpointBehaviors[typeof(WebHttpByteResponseBehavior)];
                contentType = behavior.DefaultOutgoingResponseFormat;
            }
            //then let's see if an explicit override is available
            if (_operationDescription.OperationBehaviors.Contains(typeof (WebInvokeAttribute)))
            {
                var behavior = (WebInvokeAttribute)_operationDescription.OperationBehaviors[typeof(WebInvokeAttribute)];
                if (behavior.IsResponseFormatSetExplicitly)
                {
                    contentType = behavior.ResponseFormat;
                }
            }
            else if (_operationDescription.OperationBehaviors.Contains(typeof(WebGetAttribute)))
            {
                var behavior = (WebGetAttribute)_operationDescription.OperationBehaviors[typeof(WebGetAttribute)];
                if (behavior.IsResponseFormatSetExplicitly)
                {
                    contentType = behavior.ResponseFormat;
                }
            }
            //finally set the content type based on whatever we found
            WebOperationContext.Current.OutgoingResponse.ContentType = MapToStringContentType(contentType);
        }
        /// <summary>
        /// Maps from a WebMessageFormat to a valid Content-Type header value.
        /// </summary>
        /// <param name="contentType"></param>
        /// <returns></returns>
        private string MapToStringContentType(WebMessageFormat contentType)
        {
            switch (contentType)
            {
                case WebMessageFormat.Xml:
                    return TEXT_XML;
                    break;
                case WebMessageFormat.Json:
                    return APPLICATION_JSON;
                    break;
                default:
                    return APPLICATION_JSON;
                    break;
            }
        }
