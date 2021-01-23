    public class DateTimeRange
    {
         public DateTime Start { get; set; }
         public DateTime End { get; set; }
         public bool Intersects(DateTimeRange test)
         {
             if(this.Start > this.End || test.Start > test.End)
                throw new InvalidDateRangeException();
             if(this.Start == this.End || test.Start == test.End)
                  return false; // No actual date range
             if(this.Start == test.Start || this.End == test.End)
                  return true; // If any set is the same time, then by default there must be some overlap. 
             if(this.Start < test.Start)
             {
                  if(this.End > test.Start && this.End < test.End)
                      return true; // Condition 1
                  if(this.End > test.End)
                      return true; // Condition 3
             }
             else
             {
                  if(test.End > this.Start && test.End < this.End)
                      return true; // Condition 2
                  if(test.End > this.End)
                      return true; // Condition 4
             }
             return false;
        }
    }
