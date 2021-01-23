    using(var ms = new MemoryStream()) {
        var settings = new XmlWriterSettings {
            Encoding = Encoding.ASCII
        };
        using(var xw = XmlWriter.Create(ms, settings)) {
            _queueSerializer.Value.Serialize(xw, _mostRecentPlayers.ToArray());
        }
        xml = Encoding.ASCII.GetString(ms.GetBuffer(), 0, (int)ms.Length);
    }
