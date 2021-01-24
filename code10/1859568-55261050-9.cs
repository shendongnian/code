    var dataRows = File.ReadLines("<path to your file>")
            .Select(line => {
                     var strings = line.Split(' ');
                     return new { Col1 = int.Parse(strings[0]),
                              Col2 = DateTime.ParseExact(
                                  strings[1],
                                  "d.M.yyyy", 
                                  CultureInfo.InvariantCulture),
                              Col3 = int.Parse(strings[2]),
                              Col4 = int.Parse(strings[3]),
                              Col5 = int.Parse(strings[4]),
                              Col6 = int.Parse(strings[5]),
                              Col7 = int.Parse(strings[6])
                     };
                   });
