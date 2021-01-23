    public bool isDomainExist(string address)
    {
        System.Net.WebRequest request = System.Net.WebRequest.Create(address);
        request.Method = "HEAD";
        try
        {
            var r = request.GetResponse();
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }
    
    console.writeline(isDomainExist("https://stackoverflow.com"));
    
