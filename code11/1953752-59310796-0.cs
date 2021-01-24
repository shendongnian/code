    private PersonalisationState ConvertBookingSummaryToPersonalisationState(BookingSummary booking)
    {
       return new PersonalisationState()
       {
               UserType = new UserType()
               {    
                    Name = booking.UserType,
                    <...>
               } 
       };
    }
