    XDocument xml = new XDocument(
       BlogDB.Visits.Select(v=>new XElement("Visit",
          new XElement("id", v.id),
          new XElement("SessionID", v.SessionID),
          new XElement("StartDate", v.StartDate),
          new XElement("Date", v.Date),
          new XElement("IPAddress", v.IPAddress),
          new XElement("WhereIsHe", v.WhereIsHe),
          new XElement("WhoIs", v.WhoIs))));
    xml.Save("filename.xml");
