    public struct StudentDetails
    {    
      public override void ToString()
      {
         return String.Format(
                    CultureInfo.CurrentCulture,
                   "FirstName: {0}; LastName: {1} ... ", 
                    this.FirstName,
                    this.LastName);
      }
    }
