    public class Foo
    {
         private List<Bar> _bars;
    
         public ReadOnlyCollection<Bar> Bars {get { return _bars.AsReadOnly; }}         
    
         internal void AddBar(Bar bar)
         {
              _bars.Add(bar);
         }
    }
