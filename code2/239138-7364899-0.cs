    var store = new X509Store(StoreLocation.CurrentUser); 
    store.Open(OpenFlags.ReadOnly); 
    var certificates = store.Certificates;
    foreach (var certificate in certificates)
    {
        var friendlyName = certificate.FriendlyName;
        var xname = certificate.GetName(); //obsolete
        Console.WriteLine(friendlyName);
    }
    store.Close();
