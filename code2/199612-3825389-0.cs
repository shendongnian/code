    public class Row
    {
    }
    public abstract class BaseDatabaseOperation
    {
        public abstract IEnumerable<Row> Execute(IEnumerable<Row> rows);
    }
    public abstract class SqlBulkInsertOperation : BaseDatabaseOperation
    {
        public override IEnumerable<Row> Execute(IEnumerable<Row> rows)
        {
            Console.WriteLine("does useful work");
            return new Row[0];
        }
    }
    public class MyOverride : SqlBulkInsertOperation
    {
        public override IEnumerable<Row> Execute(IEnumerable<Row> rows)
    {
        
            Console.WriteLine("do own work here");
        //This does not execute code in base class!
            base.Execute(rows);
            return new Row[0];
    }
    }
