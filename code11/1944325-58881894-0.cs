    namespace MoCApp.ViewModels
    {
        public class SLGAdminCreateViewModel
        {
            public SLGHeader SLGHeader;
            [Range(-100.00, 100.00, ErrorMessage = "Value must be between -100 and 100")]
            public decimal? TotalBudget { get; set; }
            [Range(-100.00, 100.00, ErrorMessage = "Value must be between -100 and 100")]
            public decimal? TotalLaborBudget { get; set; }
    
            public List<QuarterWeekType> DropDownList { get; set; }
    
            public SLGQuarterDetails SLGQuarterList { get; set; }
    
            public QuarterWeekType Dropdown { get; set; }
    
            public string SelectedDropDownValue { get; set; }
    
            public List<string> DropDownListAutoPopulate { get; set; }
        }
    }
