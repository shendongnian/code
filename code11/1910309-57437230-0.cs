    var lines = new List<string>
    {
        @"1H|\^&|||XS^00-20^69652^^^^05342311||||||||E1394-97 2",
        @"2P|1|||4422/12/17|^Turinawe^ROBERT||19831013|M|||||||||||||||||^^^MHC 4",
        @"3C|1 3"
    };
    for (int i = 0; i < lines.Count; i++)
    {
        lines[i] = lines[i].Substring(1);
    }
