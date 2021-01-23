    public Dictionary<string, string> ValidationErrors = new Dictionary<string, string>();
    public string this[string columnName]
    {
      get
       {
         // Remove Property error from ValidationErrors prior to any validation
         ValidationErrors.Remove(propertyName);
         //----------------------------------------
         string Result = null;
         if (columnName == "FirstName")
         {
            if (String.IsNullOrEmpty(FirstName))
            {
               // Add Property error to ValidationErrors Dic
               ValidationErrors[propertyName] = Result = "Please enter first name";
               //----------------------------------------
            }
         }
         else if (columnName == "LastName")
         {
            if (String.IsNullOrEmpty(LastName))
            {
              // Add Property error to ValidationErrors Dic
              ValidationErrors[propertyName] = Result = "Please enter last name";
              //----------------------------------------
            }
         }
        // Send MVVM-Light message and receive it in the Code Behind or VM
        Messenger.Default.Send<PersonInfoMsg>(new PersonInfoMsg());
        //----------------------------------------
        return Result;
      }
    }
