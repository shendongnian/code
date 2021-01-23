    public class MyModel
    {  
        int prop1 {get;set;}  
        int propn {get;set;}
    }
    var OutputDailyAppointments1 = TheOutputSoFar
       .Select((a, i) => new {Item = a, TheIndex = i}; // anonymous object captures index
