    var client = myObj["client"];
    var propertyNames = client.GetType().GetProperties().Select(p => p.Name).ToArray();
    foreach(var property in propertyNames) {
        var minVersion = client[property]["minVersion"];
        Console.WriteLine($"Client[{property}] Min Version : {minVersion}");
    }
