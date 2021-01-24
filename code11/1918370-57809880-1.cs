    public sealed class StatMod: SmartEnum<StatMod>
    {
        public static readonly StatMod FlatAdd = new StatMod(nameof(FlatAdd), 200, (prev, val)=>prev+val);
        public static readonly StatMod PercentAdd = new StatMod(nameof(PercentAdd), 300, (prev,val)=>prior + prior * value);
    
        private StatMod(string name, int value, Func<float, float, float> reduce) : base(name, value)
        {
          this.Reduce = reduce;
        }
    
        public Func<float, float, float> Reduce {get;}
    }
    
    public float Value => StatModifiers
      .Aggregate(_baseValue, (prior, mod) => mod.Reduce(prev, mod.Value));
