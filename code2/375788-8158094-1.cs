      struct MonthData 
      {    
          public List<DataRow> Frontline;
          public List<DataRow> Leadership; 
          private MonthData(List<DataRow> frontLine = null, 
                            List<DataRow> leadership = null)
          { 
             Frontline = frontLine;
             Leadership = leadership;  
          }
          public static MonthData Factory(
              List<DataRow> frontLine, List<DataRow> leadership)
          { return new MonthData(frontLine, leadership); }
      } 
