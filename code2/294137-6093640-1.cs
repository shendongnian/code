    string line;
    System.IO.StreamReader file = new System.IO.StreamReader(filename);
    Job myJob = null;
    while((line = file.ReadLine()) != null)
    {
        var lineType = getLineType(line);
        switch(lineType){
            case Job:
               myJob = new Job();
               break;
            case Detail:
               Detail myDetail = new Detail();
               myJob.Details.Add(myDetail);
               break;
    }
