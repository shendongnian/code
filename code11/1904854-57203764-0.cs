    // Merges both objects
    List<DataDictionary> duplicatesRemovedLists = ColumnsDataDict.Concat (ColumnsWizard).ToList ();
    // Removes common objects based on its property value (eg: TableName)
    foreach (var cddProp in ColumnsDataDict) {
      foreach (var cwProp in ColumnsWizard) {
        if ((cddProp.TableName == cwProp.TableName)) {
          duplicatesRemovedLists.Remove (cddProp);
          duplicatesRemovedLists.Remove (cwProp);
        }
      }
    }
    
    // Prints expected output
    foreach (DataDictionary item in duplicatesRemovedLists) Console.WriteLine (item.TableName);
