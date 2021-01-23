    mem.Write(doc, 0, doc.Length);
    mem.Position = 0; // new, perhaps this is relevant for Package.Open ?
    Package pack = Package.Open(mem, FileMode.Open, FileAccess.ReadWrite);
    filler.FillTemplate(ref pack, someIrreleventData);
    pack.Flush(); pack.Close(); // new
    mem.Position = 0;  // new
