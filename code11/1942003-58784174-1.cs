    foreach (string x in dataSet)
    {
      int parsed;
      bool success = Int32.TryParse(x, out parsed);
      if(success){
        parsedDataSet.Add(parsed);
      }
      else{
        //parsed has to be set by compiler rules for out.
        //So it is 0 at this. You propably do not want add it to that collection
        //Indeed the else is only here for that comment.
      }
    }
