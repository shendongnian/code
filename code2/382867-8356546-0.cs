    public class Closure<TObject, TVariable>
    {
        public Closure(TObject obj, TVariable var){
           this.Variable = var;
           this.Predicate = obj;
        }
        public TVariable Variable { get; set; }
        public Func<TObject, bool> Predicate { get; set; }
    }
