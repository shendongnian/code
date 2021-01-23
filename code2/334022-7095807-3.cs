    public interface IMyInterfaceA<TPoco>
       where TPoco : IMyInterfaceB
    {     
       TPoco B { get; set; } 
    } 
    public class pocoOneA<TPoco> : IMyInterfaceA<TPoco>
      where TPoco : IMyInterfaceB
    {     
       public TPoco B { get; set; }  // fails, can I strongly type an interface?? 
    } 
