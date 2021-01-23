    public class MyModel
    {
      int prop1 {get;set;}
      int propn {get;set;}
      public int TheIndex {get;set;}
    }
    
    var outputDailyAppointments1 = TheOutputSoFar.Select((a, i) =>
        new ViewDailyAppointmentsModel{TheIndex = i});
