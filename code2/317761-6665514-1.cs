     public interface IMyChoice
     {
          public bool IsSelected { get; }
          public IMyOperations GetWorker();
     } 
     public class ChoiceFoo : IMyChoice
     {
       
     
     }
     public class ChoiceBar : IMyChoice
     {
     }
     public class ChoiceBaz : IMyChoice
     {
     }
