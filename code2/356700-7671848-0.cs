    public string MyDateStr 
    {
       get 
       {
           return MyDateDate == null ? "" : MyDateDate.ToShortDateString();
       }
       set
       {
          // Usually a tryParse for the string value
       }
    }
