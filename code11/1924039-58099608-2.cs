Given the API returns items for currentTime
Given the database1 returns items for rightNowTime
Given the database2 returns items for presentTime
       
        public class binding {
        
                public DateTime datetime;
        
    [Given(@"the API returns items for (.*)")]
    [Given(@"Given the database1 returns items for (.*)")] 
    [Given(@"Given the database2 returns items for (.*)")] 
       
     public void currentDatetime(DateTime dt)
                {          
                    log.Info("current time: " + datetime);
                     log.Info("current date: " + datetime.Date);
                    
                }
        
              [StepArgumentTransformation]
               public DateTime convertToDatetime(string c)
                {
                     datetime = DateTime.Now;
                     return datetime;
                }
        
        }
