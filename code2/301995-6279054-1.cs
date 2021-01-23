    public static List<Budget> GetBudgets()
    {
        XDocument data = XDocument.Load(HttpContext.Current.Server.MapPath("~/Data/Budgets.xml"));
     
        return (from b in data.Descendants("Budget")
                orderby b.Attribute("Datum")
                select new Budget()
                {
                    Einnahmen = b.Element("Einnahmen").Value,
                    AnmerkungEinnahme= b.Element("Anmerkung_Einnahme").Value,
                    Ausgaben = b.Element("Ausgaben").Value,
                    AnmerkungAusgabe= b.Element("Anmerkung_Ausgabe").Value,
                    Datum = b.Element("Datum").Value
     
                }).ToList();
    }
