    string errorMessage = null;
    
    // A class derived from System.ServiceModel.ClientBase.
    MyWebService wcfClient = new MyWebService();
    try
    {
       wcfClient.Open();
       wcfClient.MyWebServiceMethod();
    }
    catch (TimeoutException timeEx)
    {
       // The service operation timed out.
       errorMessage = timeEx.Message;
    }
    catch (FaultException<ExceptionDetail> declaredFaultEx)
    {
       // An error on the service, transmitted via declared SOAP
       // fault (specified in the contract for an operation).
       errorMessage = declaredFaultEx.Detail.Message;
    }
    catch (FaultException unknownFaultEx)
    {
       // An error on the service, transmitted via undeclared SOAP
       // fault (not specified in the contract for an operation).
       errorMessage = unknownFaultEx.Message;
    }
    catch (CommunicationException commEx)
    {
       // A communication error in either the service or client application.
       errorMessage = commEx.Message;
    }
    finally
    {
       if (wcfClient.State == CommunicationState.Faulted)
          wcfClient.Abort();
       else
          wcfClient.Close();
    }
