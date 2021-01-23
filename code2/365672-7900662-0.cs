    DateTime dteSrc, dteDest;
    if(DateTime.TryParse(srcData.ToString(), out dteSrc) && DateTime.TryParse(currentDataObj.ToString(), out dteDest))
    {
      if (dteSrc == dteDest) { 
          // Get a "use of unassignned local variable 'dteDest' 
          // unless dteDest = DateTime.MinValue beforehand
      }
    }
