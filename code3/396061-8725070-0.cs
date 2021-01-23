    public Task<bool> ConnectAsync()
    {
        return TaskEx.Run( () =>
            {
                bool success = true;
                Pop3Client client = new Pop3Client();
                try
                {
                    client.Connect("mail.server.com", 110, false);
                    client.Authenticate("username", "password");
                }
                catch
                {
                    success = false;
                }
                return success;
            }
        );
    }
