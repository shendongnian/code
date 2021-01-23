        var s = Assembly.GetExecutingAssembly().GetManifestResourceStream("Model1.ssdl");
        var ssdlFilePath = "<some-dir>\file1.ssdl";
        using (var file = File.Create(ssdlFilePath))
        {
            StreamUtil.Copy(s, file);
        }
        var str = File.ReadAllText(ssdlFilePath);
        str = str.Replace("old provider token", "ProviderManifestToken=\"4.0\"");
        str = str.Replace("old provider type"", "Provider=\"System.Data.SqlServerCe.4.0\"");
        File.WriteAllText(ssdlFilePath, str);
