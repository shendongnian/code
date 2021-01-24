    // OnPost
    public async Task<IActionResult> OnPostAsync()
    {
        var newYear = Request.Form["txtYear"];                              
        DateTime yearEndMarker = Convert.ToDateTime("12/31/"                                                         
            + newYear);
    
        var newSunday = Request.Form["txtSunday"];                          
        DateTime currentSunday = 
                              Convert.ToDateTime(newSunday);             
        
        do
        {
           //the next three lines makes each iteration      
           //appear as a new record to be saved 
           scheduleIn = new ScheduleIn()
           {
               DOT = currentSunday
           };
        
             _db.ScheduleIn.Add(scheduleIn);
             await _db.SaveChangesAsync();
        
             currentSunday = currentSunday.AddDays(7);
        
       } while (currentSunday.Date <=  
                                   yearEndMarker.Date);
        
         Message = "The year " + newYear + " has been 
                    successfully initialized";
        
         return RedirectToPage("Index");                         
     }
