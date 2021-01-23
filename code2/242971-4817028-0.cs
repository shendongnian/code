    class TempConverter 
    {
      public string degreeType {get; set;}
      public double userTemp {get; set;}
    
      public TempConverter(){}
    
      public double convert()
      { 
        switch(this.degreeType)
        {
           case "F":
              return this.convertToF();
           case "C":
              return this.convertToC();
           default:
              return null;  
        }
         
      }
      public double convertToF()
      {
           return //user temp converted to F
      }
      
      public double convertToC()
      {
           return //user temp converted to C
      }
    }
