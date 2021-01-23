    static readonly XNamespace ns = XNamespace.Get("urn:crystal-reports:schemas");
    
    string GetFieldValue(XElement fs, string fieldName)
    {
        return (from fo in fs.Descendants(ns + "FormattedReportObject")
                where fo.Attribute("FieldName").Value == fieldName
                let e = fo.Element(ns + "Value")
                select e.Value).Single();
    }
    …
    var flts = (from fs in xDoc.Descendants(ns + "FormattedSection")
                select new FlightSchedule
                {
                    AircraftType = GetFieldValue(fs, "{AIRCRAFT.Type ID}"),
                    …
                }).ToList();
