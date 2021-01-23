    //namespace has to be the same as TaskWeek that your model generated
    public partial class TaskWeek
    {
        public DateTime EndDate { get; set; }
    
        public string PersianEndDate
        {
            get
            {
                return UIUtility.ConvertToPersianDate(EndDate);
            }
        }
    }
