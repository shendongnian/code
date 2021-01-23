    bool skipCurrentCart = false;
    var cartFileName = "yourcartfile";
    var tmpFileName = Path.GetTempFileName();
    using (var reader = new StreamReader(cartFileName))
    using (var writer = new StreamWriter(tmpFileName))
    {
        while (!reader.EndOfStream)
        {
             var line = reader.ReadLine();
             if (!skipCurrentCart)
             {
                 writer.WriteLine(line);
             }
             if (line.StartsWith(string.Format("#### ID: {0} NAME: card_inventory ####", cartIdToIgnore)))
             {
                 skipCurrentCart = true;
             }
             else if (line.StartsWith("#### ENDCARD ####"))
             {
                 skipCurrentCart = false;
             }
        }
    }
    // replace cart file
    File.Move(tmpFileName, cartFileName);
