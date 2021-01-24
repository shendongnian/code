    public void OnFileNameChanged(string fileName)
    {
       var calculatedValues = CalculateValues(//might need some params here)
                                  
       _view.A = calculatedValues.A;
       _view.B = calculatedValues.B;
       _view.C = calculatedValues.C;
    }
    
    public MyReturnType CalculateValues()
    {
         var result = new MyReturnType();
         var config = FirstPrivateOperation();
         if ( config == null ) { return result; }
    
         //etc etc
    }
    
    public MyReturnType
    {  
          public Whatever A { get;set }
          public Whatever B { get;set }
          public Whatever C { get;set }
    }
