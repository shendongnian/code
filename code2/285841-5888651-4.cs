    public class MyServiceBinding : CustomBinding
    {
        public MyServiceBinding()
        {
            BinaryMessageEncodingBindingElement binaryEncodingElement = new BinaryMessageEncodingBindingElement();
    #if !SILVERLIGHT
            binaryEncodingElement.ReaderQuotas.MaxArrayLength = int.MaxValue;
    #endif
            Elements.Add(binaryEncodingElement);
            Elements.Add(new HttpTransportBindingElement() { MaxReceivedMessageSize = int.MaxValue });
        }
    }
