    public class ConcreteTableA : ITable<ConcreteRowA>
    {
        void InsertRow(ConcreteRowA row); 
    }
    
    public class ConcreteRowA : IRow
    {
    }
    public class ConcreteTableB : ITable<ConcreteRowB>
    {
        void InsertRow(ConcreteRowB row); 
    }
    public class ConcreteRowB : IRow
    {
    }
    
