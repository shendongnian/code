	class PayrollRecord 
	{
		public int EmployeeID { get; set; }
		[TypeConverter(typeof(DollarsConverter))]
		public decimal RegularPay   { get; set; }
		[TypeConverter(typeof(HoursConverter))]
		public decimal RegularHours { get; set; }
		[TypeConverter(typeof(PayRateConverter))]
		public decimal RegularRate  { get; set; }
		[TypeConverter(typeof(DollarsConverter))]
		public decimal OvertimePay   { get; set; }
		[TypeConverter(typeof(HoursConverter))]
		public decimal OvertimeHours { get; set; }
		[TypeConverter(typeof(PayRateConverter))]
		public decimal OvertimeRate  { get; set; }
		// many many more
	}
