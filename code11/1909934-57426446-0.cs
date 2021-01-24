    async private void login(Object sender, EventArgs e)
    {
        string email = lbl_email.Text;
        string password = lbl_password.Text;
        string url = "http://192.168.178.77/TestLoginURL/api/login.php";
    
        Users users = new Users();
    
        FormUrlEncodedContent formContent = new FormUrlEncodedContent(new[]
        {
          new KeyValuePair<string, string>("email", email),
          new KeyValuePair<string, string>("password", password),
        });
    
        HttpClient client = new HttpClient();
        client.DefaultRequestHeaders.Add("Accept", "application/json");
        
        try
        {
            CancellationTokenSource cts = new CancellationTokenSource();
            var responseMessage = client.PostAsync(url, formContent).Result;
            var data = await responseMessage.Content.ReadAsStringAsync();
            users = JsonConvert.DeserializeObject<Users>(data);
            lbl_nickname.Text = users.UsersUsers[0].nickname;
    
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
            throw;
        }
    }
