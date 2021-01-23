    var xnameSpace = new XmlSerializerNamespaces();
    xnameSpace.Add("", "");
    var ser = new XmlSerializer(typeof (CallConnectRequest));
    ser.Serialize(destination, new CallConnectRequest {
        RequestId = 9,
        MessageNumber = 2,
        LocalCallId = 0
    }, xnameSpace);
