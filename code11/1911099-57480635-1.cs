    using System.ComponentModel.DataAnnotations;
    public class DateModel
    {
        [DisplayFormat(DataFormatString = Constants.DateOnlyFormat)]
        public DateTime StartDate { get; set; }
        [DisplayFormat(DataFormatString = Constants.DateOnlyFormat)]
        public DateTime EndDate { get; set; }
    }
    public static class Constants
    {
        public const string DateOnlyFormat = "{0:MM/dd/yyyy}";
    }
