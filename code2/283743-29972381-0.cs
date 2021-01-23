        var oldBinding = new BasicHttpBinding(BasicHttpSecurityMode.TransportWithMessageCredential);
        oldBinding.Security.Message.ClientCredentialType = BasicHttpMessageCredentialType.UserName;
        //remove the timestamp
        BindingElementCollection elements = oldBinding.CreateBindingElements();
        elements.Find<SecurityBindingElement>().IncludeTimestamp = false;
        //sets the content type to application/soap+xml
        elements.Find<TextMessageEncodingBindingElement>().MessageVersion = MessageVersion.Soap11;
        CustomBinding newBinding = new CustomBinding(elements);
