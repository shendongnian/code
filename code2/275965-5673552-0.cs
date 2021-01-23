    EndpointAddress serviceAddress = new EndpointAddress("<mycameraurl:<mycameraport>/onvif/device_service");
    HttpTransportBindingElement httpBinding = new HttpTransportBindingElement();
    httpBinding.AuthenticationScheme = AuthenticationSchemes.Digest;
    var messageElement = new TextMessageEncodingBindingElement();
    messageElement.MessageVersion = MessageVersion.CreateVersion(EnvelopeVersion.Soap12, AddressingVersion.None);
    CustomBinding bind = new CustomBinding(messageElement, httpBinding);
    // Add our custom behavior - this require the Microsoft WSE 3.0 SDK
    PasswordDigestBehavior behavior = new PasswordDigestBehavior(CameraASCIIStringLogin, CameraASCIIStringPassword);
    DeviceClient client = new DeviceClient(bind, serviceAddress);
    client.Endpoint.Behaviors.Add(behavior);
    // We can now ask for information
    client.GetSystemDateAndTime();
    client.GetNetworkInterfaces();
    client.GetScopes();
    client.GetRelayOutputs();
    client.GetWsdlUrl();
