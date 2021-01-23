    public class Closure<TObject, TVariable>
    {
        public TVariable Variable { get; set; }
        public Func<TVariable, TObject, bool> OpenPredicate { get; set; }
    
        public bool ClosedPredicate(TObject o)
        {
          return OpenPredicate(this, o);
        }
    }
    private Closure<Item, DateTime> closure = null;
    public IEnumerable<Item> GetDayData(DateTime day)
    {
        if (closure == null)
        {
            this.closure = new Closure<Item, DateTime>() {
                Predicate = (closure, i) => i.IsValidForDay(closure.Variable)
            }
        }
        closure.Variable=day;
        this.items.Where(this.closure.Predicate);
    }
