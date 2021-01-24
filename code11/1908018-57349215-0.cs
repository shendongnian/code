    // Get the cert
    var myCertificate = await GetMyCertificate(); //X509Cert
    
    // Create a new binding to specify certificate security
    var binding = new BasicHttpsBinding()
    {
    	Name = "basic_ssl_cert"
    };
    
    // Specify the credential type
    binding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Certificate;
    
    
    //Create instance of SOAP client
    QaPaymentService.PaymentOnlineService_v2_Client soapClient = new QaPaymentService.PaymentOnlineService_v2_Client(binding, new EndpointAddress(onlinePaymentServiceEndpoint));
    
    // Add the certificate to the client
    soapClient.ClientCredentials.ClientCertificate.Certificate = myCertificate;
    
    
    using (new OperationContextScope(soapClient.InnerChannel))
    {
    	try
    	{
    		var result = soapClient.completeOnlineCollectionAsync(new QaPaymentService.CompleteOnlineCollectionRequest
    		{
    			app_id = appId,
    			token = token			
    		}).GetAwaiter().GetResult();
    
    		return (result.completeOnlineCollectionResponse.tracking_id);
    	}
    	catch (FaultException<QaPaymentService.PaymentServiceFault> ex)
    	{
    		// Extract the actuall error from the service fault
    		throw new myServiceException(ex.Detail.return_detail, ex)
    		{
    			ErrorDetail = ex.Detail.return_detail,
    			ErrorCode = ex.Detail.return_code
    		};                       
    	}
    	catch (Exception ex)
    	{
    		logger.LogError($"Error completing transaction from QA my service: {ex.Message}", ex);
    		throw ex;
    	}
    }           
