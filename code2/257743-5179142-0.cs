    TypedMessageConverter converter = TypedMessageConverter.Create(
        typeof( CustomMessage ),
        "http://schemas.cyclone.com/2011/03/services/Service/GetData",
        "http://schemas.cyclone.com/2011/03/data",
        new DataContractFormatAttribute() { Style = OperationFormatStyle.Rpc } );
    CustomMessage body = new CustomMessage()
    {
        // Setting of properties omitted
    };
    Message message = converter.ToMessage( body, MessageVersion.Soap12 );
    string soapMessage = message.ToString();
