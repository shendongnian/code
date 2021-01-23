    // Make your key the device name
    var qrHash = new Dictionary<string, List<QuickReport>>();
    // Populate your QR Dictionary here.
    var output = new StringBuilder();
    foreach (var keyValuePair in qrHash)
    {
        output.Append(keyValuePair.Key);
        var gnd = new StringBuilder("GND: ");
        var nt = new StringBuilder("NT_IOp: ");
        foreach (var qr in keyValuePair.Value)
        {
            gnd.Append(qr.GroupName);
            nt.Append(qr.PinName);
        }
        output.Append(gnd);
        output.Append(nt);
    }
