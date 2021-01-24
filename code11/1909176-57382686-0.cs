    //Wire1{"HC:1", "OGB:2", "KEL:1", "ORG:8", "HAS:10" }
    List<HarnessAndHousings> wire1 = new List<HarnessAndHousings>();
    //Wire2{"HC:1", "OSB:1", "KEL:1", "ORG:1", "HPS:5", "ORG:12", "HAS:25"}
    List<HarnessAndHousings> wire2 = new List<HarnessAndHousings>();
    
    //matching: {"HC:1", "KEL:1" }
    List<HarnessAndHousings> matchingWires = wire1.Intersect(wire2);
