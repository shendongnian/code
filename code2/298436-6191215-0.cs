     [DataContract] 
     public class Foo : IFoo
     {
         [DataMember(IsRequired = true)]
         public int bar { get; set; } 
     }
      
     public interface IFoo 
     {
         [MyCustomAttribute(...)]
         int bar { get; set; } 
     }
