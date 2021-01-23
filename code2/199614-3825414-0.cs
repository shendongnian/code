    class Program
    {
        public class Row { }
    
        public abstract class BaseDatabaseOperation
        {
            public abstract IEnumerable<Row> Execute(IEnumerable<Row> rows);
        }
    
        public abstract class SqlBulkInsertOperation : BaseDatabaseOperation
        {
            public override IEnumerable<Row> Execute(IEnumerable<Row> rows)
            {
                Console.WriteLine("done");
                return rows;
            }
        }
    
        public class MyOverride : SqlBulkInsertOperation
        {
            public override IEnumerable<Row> Execute(IEnumerable<Row> rows)
            {
                return base.Execute(rows);
            }
        }
    
        static void Main(string[] args)
        {
            var x = new MyOverride();
            x.Execute(null);
        }
    }
