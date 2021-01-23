    using (StreamWriter sw = new StreamWriter(ms))
        {
    foreach (Conflict ct in Conflicts)                                    xmlSerializer.Serialize(sw, ct);
    sw.Flush(); //Site tip
    ms.Position = 0;  //Site tip
    }
