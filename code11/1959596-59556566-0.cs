    using (var formContent = new MultipartFormDataContent("NKdKd9Yk")) {
        formContent.Headers.ContentType.MediaType = "multipart/form-data";
        var id = App.User.Id.ToString();
        StringContent UserIdContent = new StringContent(id, Encoding.UTF8, "application/x-www-form-urlencoded");
        formContent.Add(UserIdContent, "id");
    
        FileStream fs = System.IO.File.OpenRead(CreatedImage);
        formContent.Add(new StreamContent(fs), "image");
    
        using (var client = new HttpClient()) {
            try {
                // 4.. Execute the MultipartPostMethod
                var message = await client.PostAsync(url, formContent);
                // 5.a Receive the response
                var result = await message.Content.ReadAsStringAsync();
    
                if (result == "Success") {
                    App.Current.MainPage = new SideMenuItems();
                }
            } catch (Exception ex) {
                // Do what you want if it fails.
                throw ex;
            }
        }
    }
        
