    public class ObjectWrapper<T> : IDisposable
    {
         public IEnumerable<T> Items { get; protected set; }
         public IEnumerable<ColumnDefinition> Definitions { get; set; }     
         public ObjectWrapper(IEnumerable<T> source) 
         { 
             Items = source; 
             Definitions = new List<ColumnDefinition>(); 
         }
         public void AddColumnDefinition(string name, Expression<Func<T, string>> propertyExpression, int width)
         {
              /* Add Column Definition with Expression Data */
         }
    }
