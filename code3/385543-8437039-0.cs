    public class MonthMap : ClassMap<Month>{
      public MonthMap(){
        CompositeId()
          .KeyProperty(x=>x.MonthNumber,"MONTH_NUMBER")
          .KeyProperty(x=>x.Year);
        Table("TAX_AUDITOR_ALLOWED_MONTHS");
      }
    }
