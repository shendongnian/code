    MessageHeader header= MessageHeader.CreateHeader("My-CustomHeader","http://myurl","Custom Header.");
           using (phptoebiTestclient.ServiceReference1.webserviceControllerPortTypeClient client = new phptoebiTestclient.ServiceReference1.webserviceControllerPortTypeClient())
           {
               using (OperationContextScope scope = new OperationContextScope(client.InnerChannel))
               {
                   OperationContext.Current.OutgoingMessageHeaders.Add(header);
                   HttpRequestMessageProperty httpRequestProperty = new HttpRequestMessageProperty();
                   byte[] toEncodeAsBytes    = System.Text.ASCIIEncoding.ASCII.GetBytes("username:password");                       
                   httpRequestProperty.Headers.Add("Authorization: Basic "+ System.Convert.ToBase64String(toEncodeAsBytes));                                              
                   OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] = httpRequestProperty;
                   string str = client.getVacanciesReference("");
               }                                 
           }
