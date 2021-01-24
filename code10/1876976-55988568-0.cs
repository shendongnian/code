    while ((line = file.ReadLine()) != null)
    {
        if (line.Length <= 0)
        {
            continue;
        }
    
        var firstComma = line.IndexOf(",");
    
        if (firstComma >= 0)
        {
            var possibleDate = line.Substring(0, firstComma);
            if (DateTime.TryParse(possibleDate, out _))
            {
                list.Add(new Whatsapp
                {
                    DateTime = line.Substring(0, line.IndexOf("-")).Replace(",", "").Trim(),
                    Date = line.Substring(0, line.IndexOf(",")).Trim(),
                    Time = line.Substring(0, line.IndexOf("-")).Trim().Substring(line.Substring(0, line.IndexOf("-")).Trim().IndexOf(",") + 2),
                    User = line.Substring(line.IndexOf("-") + 2).Substring(0, line.Substring(line.IndexOf("-") + 2).IndexOf(":")).Trim(),
                    Message = line.Substring(line.IndexOf("-") + 2).Trim().Substring(line.Substring(line.IndexOf("-") + 2).Trim().IndexOf(":") + 2).Trim()
                });
            }
            else
            {
                list.Last().Message += $"{line.Trim()}\r\n";
            }
        }
        else
        {
            list.Last().Message += $"{line.Trim()}\r\n";
        }
    }
