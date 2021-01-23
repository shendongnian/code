    string line;
    System.IO.StreamReader file = new System.IO.StreamReader(filename);
    Job myJob = null;
    Detail myDetail = null;
    while((line = file.ReadLine()) != null)
    {
        var lineType = getLineType(line);
        switch(lineType){
            case Job:
               myJob = new Job();
               break;
            case newDetail:
               if(myDetail != null)
               {
                   myJob.Details.Add(myDetail); 
               }
               Detail myDetail = new Detail();
               break;
            case continueDetail:
               //set some detail properties
               break;
       }
