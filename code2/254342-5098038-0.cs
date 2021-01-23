    class Program
    {
        static void Main(string[] args)
        {
            DateTime stopPaymentStartDate = new DateTime(2011, 08, 1);
            DateTime stopPaymentEndDate = new DateTime(2011, 10, 20);
    
            MembershipPeriod gymMembership = new MembershipPeriod 
            { 
                MembershipType = MembershipType.Gym, 
                StartDate = new DateTime(2011, 07, 25), 
                EndDate = new DateTime(2011, 10, 10) 
            };
    
            MembershipPeriod magazineMembership = new MembershipPeriod 
            { 
                MembershipType = MembershipType.Magazine, 
                StartDate = new DateTime(2011, 08, 5), 
                EndDate = new DateTime(2011, 10, 5) 
            };
    
            MembershipPeriod hotelMembership = new MembershipPeriod
            { 
                MembershipType = MembershipType.Hotel, 
                StartDate = new DateTime(2011, 08, 20), 
                EndDate = new DateTime(2011, 11, 8) 
            };
    
            List<MembershipPeriod> resultsGym = GetResultsForPeriod(gymMembership, stopPaymentStartDate, stopPaymentEndDate);
            List<MembershipPeriod> resultsmagazine = GetResultsForPeriod(magazineMembership, stopPaymentStartDate, stopPaymentEndDate);
            List<MembershipPeriod> resultshotel = GetResultsForPeriod(hotelMembership, stopPaymentStartDate, stopPaymentEndDate);
        }
    
        private static List<MembershipPeriod> GetResultsForPeriod(MembershipPeriod period, DateTime stopPaymentStartDate, DateTime stopPaymentEndDate)
        {
            List<DateTime> datesToKeep = new List<DateTime>();
    
            for (DateTime date = stopPaymentStartDate.Date; date <= stopPaymentEndDate.Date; date = date.AddDays(1))
            {
                if (date <= period.StartDate.Date || date >= period.EndDate.Date)
                {
                    datesToKeep.Add(date);
                }
            }
    
            List<MembershipPeriod> results = new List<MembershipPeriod>();
            MembershipPeriod newPeriod = null;
            
            for (int i = 0; i < datesToKeep.Count; i++)
            {
                if (newPeriod == null)
                {
                    newPeriod = new MembershipPeriod();
                    newPeriod.MembershipType = period.MembershipType;
                    newPeriod.StartDate = datesToKeep[i];
                }
    
                if (i == datesToKeep.Count - 1 || (datesToKeep[i + 1] - datesToKeep[i]).Days > 1)
                {
                    newPeriod.EndDate = datesToKeep[i];
                    results.Add(newPeriod);
                    newPeriod = null;
                }
            }
    
            return results;
        }
    }
    
    public enum MembershipType 
    { 
        Gym = 1, 
        Magazine = 2, 
        Hotel = 3 
    }
    
    public class MembershipPeriod 
    { 
        public DateTime StartDate 
        { 
            get; 
            set; 
        } 
        
        public DateTime EndDate 
        { 
            get; 
            set; 
        } 
        
        public MembershipType MembershipType 
        { 
            get; 
            set; 
        } 
    } 
