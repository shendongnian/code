        public void Execute()
        {
            var getallemployees = new List<Employee>(); // for demo purposes; change accordingly
            var getemployeecoupon = new List<EmployeeCoupon>(); // for demo purposes; change accordingly
            CultureInfo myCI = new CultureInfo("en-US");
            Calendar myCal = myCI.Calendar;
            CalendarWeekRule myCWR = myCI.DateTimeFormat.CalendarWeekRule;
            DayOfWeek myFirstDOW = myCI.DateTimeFormat.FirstDayOfWeek;
            // You can call the maCal.GetWeekOfYear function whenever your original coupon is created; then you won't need this iteration
            foreach (EmployeeCoupon coup in getemployeecoupon)
                coup.WeekOfYear = myCal.GetWeekOfYear(coup.CreationTime, myCWR, myFirstDOW); // You might want to use coup.DateUsed here, depending on your business rule
            var employeecoupon = (from coup in getemployeecoupon
                                  join emplo in getallemployees on coup.PhoneNumber equals emplo.PhoneNumber
                                  where coup.CreationTime.DayOfWeek >= DayOfWeek.Sunday
                                  && coup.CreationTime.DayOfWeek <= DayOfWeek.Saturday
                                  select new CouponDTO
                                  {
                                      PhoneNumber = coup.PhoneNumber,
                                      Email = emplo.Email,
                                      DateCreated = coup.CreationTime,
                                      DateUsed = coup.DateUsed,
                                      WeekOfYear = coup.WeekOfYear,
                                  }).Count();
        }
        public class CouponDTO
        {
            public string PhoneNumber { get; set; }
            public string Email { get; set; }
            public int WeekOfYear { get; set; }
            public DateTime DateCreated { get; set; }
            public DateTime DateUsed { get; set; }
        }
        public class Employee
        {
            public string PhoneNumber { get; set; }
            public string Email { get; set; }
        }
        public class EmployeeCoupon
        {
            public string PhoneNumber { get; set; }
            public int WeekOfYear { get; set; }
            public DateTime CreationTime { get; set; }
            public DateTime DateUsed { get; set; }
        }
