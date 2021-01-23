    > The DynamicProxy allows you to create the dynamic WCF client at runtime by specifying the WSDL URI of the service. The DynamicProxy does not depend on the precompiled proxy or configuration. The DynamicProxy uses the MetadataResolver to download the metadata from the service and WsdlImporter to create the contract and binding at runtime. The compiled dynamic proxy can be used to invoke the operations on the service using reflection.
    > The example shows how you can the dynamic proxy to invoke operations that use simple types and complex types. The flow of usage is as following.
    > 
    > 1. Create the ProxyFactory specifying the WSDL URI of the service.
    > 
        DynamicProxyFactory factory = new DynamicProxyFactory("http://localhost:8080/WcfSamples/DynamicProxy?wsdl");
    > 2. Browse the endpoints, metadata, contracts etc. 
        factory.Endpoints factory.Metadata factory.Contracts factory.Bindings
    > 3. Create DynamicProxy to an endpoint by specifying either the endpoint or contract name.
        DynamicProxy proxy = factory.CreateProxy("ISimpleCalculator");
    > OR
        DynamicProxy proxy = factory.CreateProxy(endpoint); 
 
    > 4. Invoke operations on the DynamicProxy 
        double result = (dobule)proxy.CallMethod("Add", 1d ,2d);
    > 5. Close the DynamicProxy 
        proxy.Close();
    > To run the example: Compile the solution, run the CalculatorService.exe and then run the CalculatorDynamicClient.exe
