    var Client = new[] { new { ClientID = 1, FullName = "Name1" }, new { ClientID = 2, FullName = "Name2_Tooley_3242343" } };
    var DriverClient = new[] { new { ClientID = 2, DriverID = 20 }, new { ClientID = 3, DriverID = 30 } };
    var result =
        from client in Client
        join driver in DriverClient on client.ClientID equals driver.ClientID into ClientDriver
        from clientDriver in ClientDriver.DefaultIfEmpty()
        where client.FullName.Contains("Tooley") && (clientDriver == null || clientDriver.DriverID != 1)
        select client;
