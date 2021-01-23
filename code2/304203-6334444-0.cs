    public interface IFace
    {
       void SampleFunc();
    }
    public class MyClass : IFace
    {
       void IFace.SampleFunc();
    }
    
    public static void Program()
    {
       MyClass instance = new MyClass();
       instance.SampleFunc(); //Illegal
       ((IFace)instance).SampleFunc(); Legal
    }
