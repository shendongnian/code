    // Create a thread running this code in your onstarted method of the service
    using System.IO;
    using System.Net;
    using System.Net.Sockets;
    
    var server = new TcpListener(IPAddress.Parse("127.0.0.1"), 8889);
    server.Start();
    
    while(true) {
      var client = server.AcceptTcpClient(); 
    
      using(var sr = new StreamReader(client.GetStream())) {
        var date = DateTime.Parse(sr.ReadToEnd());
        Console.WriteLine(date);
      } 
    }
    
    // In the console
    using System.IO;
    using System.Net;
    using System.Net.Sockets;
    
    var client = new TcpClient("localhost",8889); 
    using(var sw = new StreamWriter(client.GetStream())) {
      sw.Write(System.DateTime.Now);
    }
    
