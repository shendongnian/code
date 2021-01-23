       struct DateRange
       {
          private readonly DateTime start;
          private readonly DateTime end;
    
          public DateRange(DateTime start, DateTime end)
          {
             start = start.Date;
             end = end.Date;
          }
    
          public DateTime Start
          {
              get
              {
                  return start;
              }
          }
    
          public DateTime End
          {
              get
              {
                  return end;
              }
          }
    
          public override int GetHashCode()
          {
              unchecked // Overflow is fine, just wrap
              {
                  int hash = 17;
                  // Suitable nullity checks etc, of course :)
                  hash = hash * 23 + start.GetHashCode();
                  hash = hash * 23 + end.GetHashCode();
                  return hash;
              }
          }
       }
