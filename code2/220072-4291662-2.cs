    List<string[]> desc = new List<string[]>();
    const string RDATAPATCH = "rctdata.xdb";
    using (StreamReader sr = new StreamReader(RDATAPATCH)) {
      string line;
      while ((line = sr.ReadLine()) != null) {
        desc.Add(line.Split('|'));
      }
    }
    desc.RemoveAt(0); // remove field description line
    desc.Sort((a, b) => {
      if (a[7] == "nedeschis" && b[7] == "nedeschis") return 0;
      if (a[7] == "nedeschis") return 1;
      if (b[7] == "nedeschis") return -1;
      return DateTime.Parse(a[7]).CompareTo(DateTime.Parse(b[7]));
    });
