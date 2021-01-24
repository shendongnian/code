cSharp
 var client = new WordPressClient("http://Your-Site/wp-json/");
            client.AuthMethod = AuthMethod.JWT;
            await client.RequestJWToken(TheUserName, ThePassword);
            var x = client;
            var isValidToken = await client.IsValidJWToken();
            WpApiCredentials.token = client.GetToken();
            if (isValidToken)
            {
                
                Login_Phase2();
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Empty Values", "Token not Found", "OK");
            }
