    public struct StudentDetails
    {    
      public override void ToString()
      {
         StringBuilder builder = new StringBuilder();
         
         builder.AppendFormat("FirstName: {0}; ", this.FirstName);
         // .. do it for all properties you want to see
    
         return builder.ToString(CultureInfo.CurrentCulture);
      }
    }
