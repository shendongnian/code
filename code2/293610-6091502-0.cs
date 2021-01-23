    foreach(var obj in allHolds)
    {
         then = obj.DateOpened;
         span = now - then;
    
         if(span.TotalHours >= 48)
         {
              obj.BackColor = Color.Red;
         }
    }
