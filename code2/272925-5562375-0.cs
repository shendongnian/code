    public class MainClass
    {
       public SampleProp property1 {get;set;}
    }
    public class SampleProp
    {
       public string property2 {get;set;}
    }
    
    MainClass test = new MainClass();
    var prop = test.property1.property2;
