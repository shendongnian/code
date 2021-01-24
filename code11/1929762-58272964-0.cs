    var badData = FileSignatures.Drive.Public.Where(
        e => (e.NetworkBlock?.Any(n => String.IsNullOrWhiteSpace(n.netId)) ?? false) &&
             String.IsNullOrWhiteSpace(
                 e.WiFiBlock?.netId) &&
                 String.IsNullOrWhiteSpace(
                     e.BluetoothBlock?.netId))
        .ToList();    
      
