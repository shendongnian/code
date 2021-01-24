      string[] item_list = {
        "PN=12345678",
        "PN=1234-5678-0001",
        "PN=1234-4321-0001;LOT=xyz" 
      };
      string report = string.Join(Environment.NewLine, item_list
        .Select(item => FormatMe(item)));
      Console.Write(report);
