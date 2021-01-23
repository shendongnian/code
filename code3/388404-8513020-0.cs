    public class ComplexViewModel 
    { 
      public ComplexDetailsViewModel Details1 { get; set; } 
      public ComplexDetailsViewModel Details2 { get; set; } 
    } 
 
    public class ComplexDetailsViewModel : PostDetailsModel
    { 
      public string DisplayValue1 { get; set; } 
      public string DisplayValue2 { get; set; } 
    } 
    public class PostModel
    {
      public PostDetailsModel Details1 { get; set; } 
      public PostDetailsModel Details2 { get; set; } 
    }
    public class PostDetailsModel  
    { 
      public int Id { get; set; } 
    } 
