    using System.Linq;
    public int Males
    {
       get
       {
           return characters != null ? characters.Count(c => c.isMale) : 0;
       }
    }
    
    public int Females
    {
        get
        {
            return characters != null ? characters.Count(c => !c.isMale) : 0;
        }
    }
