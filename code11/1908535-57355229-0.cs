    string connectionString = ConfigurationManager.ConnectionStrings["Connect"].ConnectionString;
    using (HttpClient client = SampleHelpers.GetHttpClient(
       connectionString,
       SampleHelpers.clientId,
       SampleHelpers.redirectUrl,"v9.0"))
    {
       Console.WriteLine("--Section 1 started--");
       string queryOptions;
       contact1.Add("firstname", "Rafel");
       contact1.Add("lastname", "Shillo");
       HttpRequestMessage createrequest1 = new HttpRequestMessage(HttpMethod.Post, 
          client.BaseAddress + "contacts");
       createrequest1.Content = new StringContent(contact1.ToString());
       createrequest1.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
           
       HttpResponseMessage createResponse1 = client.SendAsync(createrequest1, 
       HttpCompletionOption.ResponseHeadersRead).Result;
       if (createResponse1.IsSuccessStatusCode)
       {
          Console.WriteLine("Contact '{0} {1}' created.", contact1.GetValue("firstname"), contact1.GetValue("lastname"));
          contact1Uri = createResponse1.Headers.GetValues("OData-EntityId").FirstOrDefault();
          entityUris.Add(contact1Uri);
          Console.WriteLine("Contact URI: {0}", contact1Uri);
       }
    }
 
