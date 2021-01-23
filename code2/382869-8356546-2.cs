    public class Closure<TObject, TVariable>
    {
        public bool Execute(TVariable _var){
           this.Variable = var;
           return this.Predicate();
        }
        public TVariable Variable { get; set; }
        public Func<TObject, bool> Predicate { get; set; }
    }
