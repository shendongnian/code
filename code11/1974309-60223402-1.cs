    public class Terms
            {
                public int Term { get; set; }
                public string TermName { get; set; }
                public string StartDate { get; set; }
                public string EndDate { get; set; }
                public DateTime RealStartDate => DateTime.Parse(StartDate);
                public DateTime RealEndDate => DateTime.Parse(EndDate);
            }
