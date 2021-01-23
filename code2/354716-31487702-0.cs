    //ArrayList Implements IEnumerable interface
    ArrayList _provinces = new System.Collections.ArrayList();
    _provinces.Add("Western");
    _provinces.Add("Eastern");
    List<string> provinces = _provinces.Cast<string>().ToList();
