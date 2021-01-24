    // 'client' side
    using (var socket = new Socket(SocketType.Stream, ProtocolType.IPv6))
    using (var networkStream = new NetworkStream(socket))
    using (var writer = new StreamWriter(networkStream))
    using (var jsonWriter = new JsonTextWriter(writer)) 
    {
        socket.Connect("localhost", 8888);
        var user = new UserInfo { Name = "Jesse de Wit" }; // That's me
        var settings = new JsonSerializerSettings()
        {
            TypeNameHandling = TypeNameHandling.Objects
        };
        var serializer = JsonSerializer.Create(settings);
        serializer.Serialize(jsonWriter, user);
    }
    
    // 'server' side
    using (var socket = new Socket(SocketType.Stream, ProtocolType.IPv6))
    using (var networkStream = new NetworkStream(socket))
    using (var reader = new StreamReader(networkStream))
    using (var jsonReader = new JsonTextReader(reader))
    {
        socket.Accept();
        var settings = new JsonSerializerSettings()
        {
            TypeNameHandling = TypeNameHandling.Objects
        };
        var serializer = JsonSerializer.Create(settings);
        // Note that obj will be a JObject if no type information is included.
        object obj = serializer.Deserialize(jsonReader);
        if (obj is UserInfo user)
        {
            // Jesse de Wit 
            Console.WriteLine(user.Name);
        }
    }
