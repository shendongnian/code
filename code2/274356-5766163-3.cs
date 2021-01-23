        public string this[string columnName]
        {
            get
        {
            //look inside person to see if it has two jobs with the same title
            string result = ValidationService.GetPersonErrors(this);
            return result;
         }
    ...
     }
