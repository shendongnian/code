    public class EffectOptions : IEnumerable<EffectOption>
    {
        public List<EffectOption> Options { get; private set; }
        public void Add(object o){
            this.Options.Add(o as EffectOption); //you may want to extend the code to check that this cast can be made,
                                                 //and throw an appropriate error (otherwise it'll add null to your list)
        }
        //IEnumerable methods
    }
