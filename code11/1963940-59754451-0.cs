    private class HolidayConstructorArgs {
        public string EmployeeCode {get;set;}
        public string Employee {get;set;}
        public string TypeOfHoliday {get;set;}
        public DateTime From {get;set;}
        public DateTime To {get;set;}
    }
    private static readonly IDictionary<string,Func<HolidayConstructorArgs,AbstractHoliday>> HolidayByTypeCode =
        new Dictionary<string,Func<HolidayConstructorArgs,AbstractHoliday>> {
            [$"{Holiday.Bereavement}"] = a => new Bereavement(a.EmployeeCode, a.Employee, a.TypeOfHoliday, a.From, a.To)
        ,   [$"{Holiday.MarriageVacation}"] = a => new MarriageVacation(a.EmployeeCode, a.Employee, a.TypeOfHoliday, a.From, a.To)
        };
