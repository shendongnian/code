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
            Console.WriteLine("base");
            return null;
        } 
    } 
     
    public class MyOverride : SqlBulkInsertOperation 
    { 
        public override IEnumerable<Row> Execute(IEnumerable<Row> rows) 
        { 
            Console.WriteLine("override");
            base.Execute(rows);
            return null;
        } 
    } 
    
    static class P 
    {
        static void Main()
        {
            var m = new MyOverride();
            m.Execute(null);
        }
    }
