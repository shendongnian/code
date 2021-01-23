    public class Town
    {
        public virtual int TownId { get; private set; }
        public virtual Dict<Language, string> AllNames { get; private set; }
        public virtual string TownName 
        { 
          get { return AllNames[CurrentLanguage]; }
        }
    }
