    public ExpertEntity SaveExpert(SaveExpertArgs args)
    {            
        string connString = ConfigurationManager.ConnectionStrings["CalendarContainer"].ConnectionString;
    
        using (CalendarContainer dbContext = new CalendarContainer(connString))
        {             
            ExpertEntity expert = (from e in dbContext.ExpertEntities
                                   where e.ExpertIdentifier == args.Expert.ExpertIdentifier
                                   select e).FirstOrDefault();
            if (expert == null)
            {
                args.Expert.ExpertIdentifier = Guid.NewGuid();
                dbContext.AddToExpertEntities(args.Expert);
            }
            //else
            //{
                dbContext.ExpertEntities.ApplyCurrentValues(args.Expert);               
    
                foreach (TimeSlotEntity t in args.Expert.TimeSlotEntities)
                {
                    dbContext.TimeSlotEntities.ApplyCurrentValues(t);
                }
            //}              
    
            dbContext.SaveChanges();
            return args.Expert;
        }
    }
