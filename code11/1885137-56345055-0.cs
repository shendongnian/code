    public class SampleViewModel
    {
        public SampleViewModel(DateTime date1, DateTime? date2 = null){
            Date1 = date1;
            Date2 = date2;
        }
        public DateTime Date1 { get; set; }        
        public DateTime? Date2 { get; set; }
        public int Diff => (Date1 - (Date2 ?? DateTime.Now)).Days;     
    }
