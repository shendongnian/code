    XmlElement root = doc.DocumentElement;
    XmlNodeList files = root.SelectNodes("//file"); // file element, not files element
    int numberOfFiles = files.Count;
    // Todo: Update progress bar here
    foreach (XmlElement file in files) // These are elements, so this cast is safe-ish
    {
        string url = file.GetAttribute("url");
        string folder = file.GetAttribute("folder");
        // If not an integer, will throw.  Could use int.TryParse instead
        int system = int.Parse(file.GetAttribute("system"));
        int size = int.Parse(file.GetAttribute("system"));
        // convert this to a byte array later
        string checksum = file.GetAttribute("checksum");
    }
