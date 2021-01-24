      string toRemove = "GTU Renewal Application (a shorter, simplified renewal form)";
      string fill = reader.ReadToEnd();
      if (fill.Contains(toRemove))
      {
           line = fill.Replace("UWNAME", UW)
                      .Replace("ClientFName", subFname)
                      .Replace("ExDate", ExpDate)
                      .Replace("UwEmail", UwEmail(UW))
                      .Replace("CinSured", client)
                      .Replace("&amp;", amperSand)
                      .Replace(toRemove, "");
      }
