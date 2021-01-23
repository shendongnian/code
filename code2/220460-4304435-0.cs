    DataContractJsonSerializer ser = new DataContractJsonSerializer(graph.GetType());
    string s;
    using(var ms = new MemoryStream()) {
        ser.WriteObject(ms, graph);
        s = Encoding.UTF8.GetString(ms.GetBuffer(), 0, (int)ms.Length);
    }
    Console.WriteLine(s);
