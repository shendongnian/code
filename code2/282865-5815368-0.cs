    switch (response.Status)
         {
             case AuthenticationStatus.Authenticated:
             var fetch = response.GetExtension<FetchResponse>();
             string email = string.Empty(); 
             if (fetch != null)
             {
                email =  fetch.GetAttributeValue(WellKnownAttributes.Contact.Email)
             }  
          break;
