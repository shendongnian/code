    using System;
    using System.Collections.Generic;
    
    public class Row {}
    
    public abstract class BaseDatabaseOperation
    {
        public abstract IEnumerable<Row> Execute(IEnumerable<Row> rows);
    }
    
    public abstract class SqlBulkInsertOperation : BaseDatabaseOperation
    {
        public override IEnumerable<Row> Execute(IEnumerable<Row> rows)
        {
            Console.WriteLine("In SqlBulkInsertOperation.Execute");
            foreach (var row in rows)
            {
                yield return row;
            }
        }
    }
    
    public class MyOverride : SqlBulkInsertOperation
    {
        public override IEnumerable<Row> Execute(IEnumerable<Row> rows)
        {
            Console.WriteLine("In MyOverride.Execute");
            return base.Execute(rows);
        }
    }
                              
    class Test
    {
        static void Main()
        {
            BaseDatabaseOperation x = new MyOverride();
            x.Execute(new Row[0]);
        }
    }
