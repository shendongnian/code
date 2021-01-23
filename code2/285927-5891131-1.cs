    var status = new bool[] { true, true, false, true };
    // alternative 1
    var statusString = string.Concat(
        status.Select((val, index) => val ? (char?)('A' + index) : null)
              .Where(x => x != null));
    // alternative 2
    var statusString2 = string.Concat( 
        status.Select((val, index) => val ? (object)(char)('A' + index) : ""));
    // alternative 3 (same as one, no boxing)
    var statusString3 = string.Concat(
        status.Select((val, index) => val ? (char)('A' + index) : ' ')
              .Where(x => x != ' '));
    // alternative 4 (no Linq, probably faster)
    var statusString4 = new StringBuilder(status.Length);
    for (int i = 0; i < status.Length; i++)
    {
        if (status[i])
            statusString4.Append((char)('A' + i));
    }
