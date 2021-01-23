      struct MonthData 
      {    
          public List<DataRow> Frontline = new List<DataRow>();
          public List<DataRow> Leadership = new List<DataRow>(); 
          private MonthData(List<DataRow> frontLine, List<DataRow> leadership)
          { 
             Frontline = frontLine;
             Leadership = leadership;  
          }
          public static MonthData Factory(
              List<DataRow> frontLine, List<DataRow> leadership)
          { return new MonthData(frontLine, leadership); }
      } 
