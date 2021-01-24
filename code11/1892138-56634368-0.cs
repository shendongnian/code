        public class GuestBasicBaseIndexVM
            {
                public IEnumerable<GuestBasicBase> Guests  { get; set; } 
                //Changed from a PaginatedList
        
                public GuestIndexFilterVM FilterVM { get; set; }
            }
