      string[] states = new string[] { "abbrev1", "abbrev2" };
      var list = new List<WorksiteGroup>();
      var item = new WorksiteGroup();
      item.Name = "Test1";
      item.IsDiscontinued = false;
      var subitem = new WorksiteGroupState();
      subitem.IsDiscountApplied = true;
      subitem.StateAbbrev = "abbrev1";
      item.ActiveStates.Add(subitem);
      list.Add(item);
      item = new WorksiteGroup();
      item.Name = "Test2";
      item.IsDiscontinued = true;
      subitem = new WorksiteGroupState();
      subitem.IsDiscountApplied = true;
      subitem.StateAbbrev = "abbrev1";
      item.ActiveStates.Add(subitem);
      list.Add(item);
      var result = list.Where(wg => wg.IsDiscontinued == false
                                 && wg.ActiveStates.Where(state => state.IsDiscountApplied == true
                                                                && states.Contains(state.StateAbbrev)).Any());
      foreach ( var value in result )
        Console.WriteLine(value.Name);
      Console.ReadKey();
