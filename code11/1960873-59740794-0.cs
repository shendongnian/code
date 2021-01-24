    var encoding = new MtomMessageEncoderBindingElement(new TextMessageEncodingBindingElement());
    var transport = new HttpTransportBindingElement();
    var customBinding = new CustomBinding(encoding, transport);
    
    
    EndpointAddress endpoint = new EndpointAddress(url);
    var channelFactory = new ChannelFactory<T>(customBinding, endpoint);
    var webService = channelFactory.CreateChannel();
    user.UserName = await webService.EncryptValueAsync(userName);
    user.Password = await webService.EncryptValueAsync(password);
    var documentAddResult = webService.DocumentAdd(document);
    channelFactory.Close();
