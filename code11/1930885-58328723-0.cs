    private async static Task SendCloudToDeviceMessageAsync()
        {
             var serviceClient = ServiceClient.CreateFromConnectionString(connectionString);
             var commandMessage = new
              Message(Encoding.ASCII.GetBytes("Cloud to device message."));
             await serviceClient.SendAsync("myFirstDevice", commandMessage);
        }
