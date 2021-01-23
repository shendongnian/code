    BasicHttpBinding binding = new BasicHttpBinding(BasicHttpSecurityMode.Transport);
    binding.MaxReceivedMessageSize = int.MaxValue;
    AWSECommerceServicePortTypeClient amazonClient = new AWSECommerceServicePortTypeClient(
                binding,
                new EndpointAddress("https://webservices.amazon.com/onca/soap?Service=AWSECommerceService"));  
    // add authentication to the ECS client
    amazonClient.ChannelFactory.Endpoint.Behaviors.Add(new AmazonSigningEndpointBehavior(accessKeyId, secretKey));
