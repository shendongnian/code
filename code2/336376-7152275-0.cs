    Regex exclude = new Regex("FID|EXCLUDE");
    foreach (var line in theFinalList.Where(
     ln => !exclude.Match(ln.PartDescription).Success && 
           !exclude.Match(ln.PartNumber ).Success))){
        string partDescription = "N/A";
        if(!string.IsNullOrWhiteSpace(line.PartDescription)){
            partDescription = line.PartDescription;
        }
        lineList.Add(partDescription  + " " + line.PartNumber + "\n");
    }
