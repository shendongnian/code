    public class MySuclass : IBaseClass1, IBaseClass2 
    {
        string IBaseClass1.SomeMethod()
        {
            return "Implementation1";
        }
        string IBaseClass2.SomeMethod()
        {
            return "Implementation2";
        }
    }
