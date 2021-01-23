    public interface ITest  
    {  
     void Method1(){}  
     void Method2(){}   
    }  
    public class Test1 : ITest  
    {  
     //Just implement Method1() (how can I just implement Method1() without implementing             Method2()?)
     public string Method1()  
     {...}
        private void ITest.Method2(){ throw new NotImplementedException(); }    
    }  
    public class Test2 : ITest  
    {  
     //Implement both Method1() & Method2()
     public string Method1()  
     {...}  
    }  
