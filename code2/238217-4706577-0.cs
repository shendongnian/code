    using (var client = new SmtpClient("somehost"))
    {
        client.DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory;
        client.PickupDirectoryLocation = @"C:\somedirectory";
        client.Send(message);
    }
