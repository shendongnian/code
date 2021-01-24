      public async Task<T> Get (string controller)
      {
         T data;
         HttpResponseMessage response = await this.HttpClient.GetAsync (UrlService.BuildEndpoint (controller));
         if (response.IsSuccessStatusCode)
         {
            data = await response.Content.ReadAsAsync<T> ();
            return data;
         }
         else
         {
            throw new Exception (); //todo
         }
      }
