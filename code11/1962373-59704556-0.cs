    public async Task LoginAsync(string username, string password) {
        try {
            OBASEMDMClient client = new OBASEMDMClient();
            var loginCredential = new LoginCredential {
                UserNameOrEMail = username,
                Password = password
            };
            var response = await client.LoginAsync(loginCredential);
            //...
        } catch (Exception e ) {
            throw e;
        }
    }
