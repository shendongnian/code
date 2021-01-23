    public class DateRangeModel
    {
    public DateRangeModel()
    {
        this.MinDateDependentProperty = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
        this.MaxDateDependentProperty = DateTime.Today.AddDays(1 - DateTime.Today.Day).AddMonths(1);
    }
    [Required]
    [CustomDateRange("2015-10-01", "2015-10-15", ErrorMessage = "Date value is not in range.")]
    [DataType(DataType.Date)]
    public DateTime DateCompareWithMinMaxValue { get; set; }
    [Required]
    [CustomDateRange(CustomDateRangeType.DependentProperty, "MinDateDependentProperty", "MaxDateDependentProperty", 
        ErrorMessage = "Date to select value is not in range.")]
    [DataType(DataType.Date)]
    public DateTime DateCompareWithMinMaxDependentProperty { get; set; }
    [Required]
    [DataType(DataType.Date)]
    public DateTime MinDateDependentProperty { get; set; }
    [Required]
    [DataType(DataType.Date)]
    public DateTime MaxDateDependentProperty { get; set; }
    }
