      struct MonthData 
      {    
          public List<DataRow> Frontline;
          public List<DataRow> Leadership; 
          private MonthData(List<DataRow> frontLine = null, 
                            List<DataRow> leadership = null)
          { 
             Frontline = frontLine?? new List<DataRow>();
             Leadership = leadership?? new List<DataRow>();  
          }
          public static MonthData Factory(
              List<DataRow> frontLine= null, 
              List<DataRow> leadership= null)
          { return new MonthData(frontLine, leadership); }
      } 
