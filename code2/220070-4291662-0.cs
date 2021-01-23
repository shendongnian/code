    List<string[]> desc = new List<string[]>();
    const string RDATAPATCH = "rctdata.xdb";
    using (StreamReader sr = new StreamReader(RDATAPATCH)) {
      string line;
      while ((line = sr.ReadLine()) != null) {
        desc.Add(line.Split('|'));
      }
    }
    desc.RemoveAt(0);
    desc.Sort((a, b) => {
      DateTime? ad = a[7] == "nedeschis" ? (DateTime?)null : DateTime.Parse(a[7]);
      DateTime? bd = b[7] == "nedeschis" ? (DateTime?)null : DateTime.Parse(b[7]);
      return ad.CompareTo(bd);
    });
