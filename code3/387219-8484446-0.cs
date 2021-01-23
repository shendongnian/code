    public class A
    {
        void DoSomethingA()
        {
        }    
    }
    .
    .
    .
    public void GenericPrint<T>(T a) where T : A
    {
        //constraint makes sure this is always valid
        a.DoSomethingA();
        Print(a);
    }
