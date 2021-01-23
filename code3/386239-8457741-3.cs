    //Generating Color Group Table
    List<ColorTable> MyColorTable = new List<ColorTable>();
    MyColorTable.Add(new ColorTable { GroupName = "Gray", ColorName = Color.Gray });
    MyColorTable.Add(new ColorTable { GroupName = "Gray", ColorName = Color.LightGray });
    MyColorTable.Add(new ColorTable { GroupName = "Green", ColorName = Color.Green });
    MyColorTable.Add(new ColorTable { GroupName = "Green", ColorName = Color.LightGreen });
    //Getting required Color Group, say "Gray"
    List<ColorTable> GreenColor = MyColorTable.Where(c => c.GroupName == "Gray").ToList();
