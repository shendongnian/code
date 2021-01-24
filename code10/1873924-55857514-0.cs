    List<ROUTE> SelectedRoutes = new List<ROUTE>();
    foreach (var route in XmlData.ROUTES)
    {
       bool bHasExitSig = false;
       if (route.GetType().GetProperty("EXITSIGNAL", typeof(string)) != null)
       {
           bHasExitSig = true;
       }
       if (sig.SignalID.Equals(route.ENTRANCESIGNAL) &&
           sig.SignalDIRECTION.Equals(route.DIRECTION) &&                     
           bHasExitSig)
       {
           SelectedRoutes.Add(route);
       }
    }
