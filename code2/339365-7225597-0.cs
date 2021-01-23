    .Select(columns => new {GuestName = ValueOrErrorMessage(columns[0]), Guest_ID = ValueOrErrorMessage(columns[1]), IC_Number = ValueOrErrorMessage(columns[2])}); 
          ...
    
    private string ValueOrErrorMessage(string input){
       if(!string.IsNullOrEmpty(input))
          return input;
       }
       return "no value"
    }
