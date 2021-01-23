    public class Membership
    {
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; } // If null then it lasts forever
    
        private DateTime NullSafeEndDate { get { return EndDate ?? DateTime.MaxValue; } }  
        
        private bool IsFullyAfter(Membership other)
        {
           return StartDate > other.NullSafeEndDate;
        }
    
        public bool Overlaps(Membership other)
        {
          return !IsFullyAfter(other) && !other.IsFullyAfter(this);
        }
    }
    
    
    public class MembershipCollection : Collection<Membership>
    {
       protected override void InsertItem(int index, Membership member)
       {
           if(CanAdd(member))
              base.InsertItem(index, member);
           else throw new ArgumentException("Ranges cannot overlap.");
       }
    
       public bool CanAdd(Membership member) 
       {
           return !this.Any(member.Overlaps);
       }
    }
