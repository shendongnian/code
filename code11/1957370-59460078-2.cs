	class PayrollRecord 
	{
		public int EmployeeID { get; set; }
		[DecimalFormat(NumericType.Dollars)]
		public decimal RegularPay   { get; set; }
		[DecimalFormat(NumericType.Hours)]
		public decimal RegularHours { get; set; }
		[DecimalFormat(NumericType.PayRate)]
		public decimal RegularRate  { get; set; }
		[DecimalFormat(NumericType.Dollars)]
		public decimal OvertimePay   { get; set; }
		[DecimalFormat(NumericType.Hours)]
		public decimal OvertimeHours { get; set; }
		[DecimalFormat(NumericType.PayRate)]
		public decimal OvertimeRate  { get; set; }
		// many many more
	}
