    public interface ITableBase{
        int Id{ get; set; }
        // other properties
        void Method1();
        int Method2();
        string Method3(int some_arguments);
    }
***
    public partial class Table1 : ITableBase{
        // implement ITableBase and other properties and methods
    }
