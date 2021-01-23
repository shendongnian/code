    --your model class
    public partial class A {
        public string a {get; set;}
    }
    
    --your project class 
    public class Ametadata {
         [Attribute("etc")]
         public string a {get; set;}
    }
    [MetadataType(typeof(Ametadata))]
    public partial class A
    {
    }
