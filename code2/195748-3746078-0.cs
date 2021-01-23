       /*
             From Azure table whitepaper
             
             When an exception occurs, you can extract the sequence number (highlighted above) of the command that caused the transaction to fail as follows:
    
    try
    {
        // ... save changes 
    }
    catch (InvalidOperationException e)
    {
        DataServiceClientException dsce = e.InnerException as DataServiceClientException;
        int? commandIndex;
        string errorMessage;
    
        ParseErrorDetails(dsce, out commandIndex, out errorMessage);
    }
    
             
              */
-
        void ParseErrorDetails( DataServiceClientException e, out string errorCode, out int? commandIndex, out string errorMessage)
        {
            GetErrorInformation(e.Message, out errorCode, out errorMessage);
            commandIndex = null;
            int indexOfSeparator = errorMessage.IndexOf(':');
            if (indexOfSeparator > 0)
            {
                int temp;
                if (Int32.TryParse(errorMessage.Substring(0, indexOfSeparator), out temp))
                {
                    commandIndex = temp;
                    errorMessage = errorMessage.Substring(indexOfSeparator + 1);
                }
            }
        }
        void GetErrorInformation(  string xmlErrorMessage,  out string errorCode, out string message)
        {
            message = null;
            errorCode = null;
            XName xnErrorCode = XName.Get("code", "http://schemas.microsoft.com/ado/2007/08/dataservices/metadata");
            XName xnMessage = XName.Get  ( "message",    "http://schemas.microsoft.com/ado/2007/08/dataservices/metadata");
            using (StringReader reader = new StringReader(xmlErrorMessage))
            {
                XDocument xDocument = null;
                try
                {
                    xDocument = XDocument.Load(reader);
                }
                catch (XmlException)
                {
                    // The XML could not be parsed. This could happen either because the connection 
                    // could not be made to the server, or if the response did not contain the
                    // error details (for example, if the response status code was neither a failure
                    // nor a success, but a 3XX code such as NotModified.
                    return;
                }
                XElement errorCodeElement =   xDocument.Descendants(xnErrorCode).FirstOrDefault();
                if (errorCodeElement == null)
                {
                    return;
                }
                errorCode = errorCodeElement.Value;
                XElement messageElement =   xDocument.Descendants(xnMessage).FirstOrDefault();
                if (messageElement != null)
                {
                    message = messageElement.Value;
                }
            }
        }
