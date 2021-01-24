    public async Task<Model> VerifyWebAppUrl(Model model)
    {
       try
       {
          var request = (HttpWebRequest)WebRequest.Create(model.URL);
          using (var response = (HttpWebResponse) await request.GetResponseAsync())
          {
             if (response.StatusCode != HttpStatusCode.OK && model.Status == "A")
                model.ChangeOfStatus = true;
             if (response.StatusCode == HttpStatusCode.OK && model.Status != "A")
                model.ChangeOfStatus = true;
          }
       }
       catch (Exception ex)
       {
          // this looks suspicious
          model.ChangeOfStatus = false;
       }
       return model;
    }
