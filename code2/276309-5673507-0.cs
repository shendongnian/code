    HttpTransportBindingElement httpBinding = new HttpTransportBindingElement();
    httpBinding.AuthenticationScheme = AuthenticationSchemes.Digest;
    var messegeElement = new TextMessageEncodingBindingElement();
    messegeElement.MessageVersion = MessageVersion.CreateVersion(EnvelopeVersion.Soap12, AddressingVersion.None);
    CustomBinding bind = new CustomBinding(messegeElement, httpBinding);
    // Add our custom behavior - this require the Microsoft WSE 3.0 SDK
    PasswordDigestBehavior behavior = new PasswordDigestBehavior(CameraASCIIStringLogin, CameraASCIIStringPassword);
    DeviceClient client = new DeviceClient(bind, serviceAddress);
    client.Endpoint.Behaviors.Add(behavior);
    // We can now ask informations
    client.GetSystemDateAndTime();
    client.GetNetworkInterfaces();
    client.GetScopes();
    client.GetRelayOutputs();
    client.GetWsdlUrl();
