    JsonSerializerOptions jso = new JsonSerializerOptions();
    jso.Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping;
    var a = new A { Name = "你好" };
    var s = JsonSerializer.Serialize(a, jso);        
    Console.WriteLine(s);
