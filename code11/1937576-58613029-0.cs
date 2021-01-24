    public class WeekObj{
    public string week {get;set;}
    public datetime startDate {get;set;}
    public datetime endDate {get;set;}
    bool isValid {get;set;}
    };
    List<WeekObj> weeks= new WeekObj();
    weeks.add(new WeekObj{"week string",startDate,endDate,false})
