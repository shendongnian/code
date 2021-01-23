    // create client, connect and log in  
    Ssh client = new Ssh();
    client.Connect(hostname);
    client.Login(username, password);
    
    // run the 'uname' command to retrieve OS info 
    string systemName = client.RunCommand("uname -a");
    // display the output 
    Console.WriteLine("OS info: {0}", systemName);
    
    client.Disconnect();
