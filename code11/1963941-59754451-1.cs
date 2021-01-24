    if (HolidayByTypeCode.TryGetValue(CmbTypeHolidays.Text, out var factory)) {
        // This is where the "magic" happens:
        // Func<> will invoke the appropriate constructor without a conditional
        var holid = factory(
            new HolidayConstructorArgs {
                EmployeeCode = CmbEmpHolidays.Text.Split('-')[0]
            ,   Employee = CmbEmpHolidays.Text.Split('-')[1]
            ,   TypeOfHoliday = CmbTypeHolidays.Text
            ,   From = Convert.ToDateTime(StartDateHolidays.Value)
            ,   To = Convert.ToDateTime(EndDateHolidays.Value)
            }
        );
        // ... The rest of your code remains the same
    }
