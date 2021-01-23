    public class DoEverything
    {
        InterfaceA A = new DerivedA();
    
        A.var1 = "Test1";
        A.var2 = "Test2";
    
        InterfaceA B = new DerivedB(A);
        write(B.var1 + ", " + B.var2);
    }
