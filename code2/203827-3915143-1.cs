    var cklContactItems = from a in dbTestCenterViews.appvuChecklistExports
                                   where a.MarketChecklistID == MCLID 
                                        && a.checklistSectionID == SID 
                                        && a.fieldGroupOrder != null
                                   orderby a.fieldGroupOrder ascending
                                   select new {
                                       a.Column1, 
                                       a.Column2, 
                                       a.Column3, 
                                       a.Column4,
                                       a.Column5,
                                       a.Column1FieldID,
                                       a.Column2FieldID,
                                       a.Column3FieldID,
                                       a.Column4FieldID,
                                       a.Column5FieldID,
                                       a.fieldGroupOrderLabel 
                                      };
    System.Diagnostics.Trace.WriteLine((query as ObjectQuery).ToTraceString());
