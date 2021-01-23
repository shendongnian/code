    public abstract class Unit()
    {
        public abstract Unit Add(Unit other);
    
        public void MatchType(Unit other)
        {
            if(this.GetType() != other.GetType()) 
                throw new ArgumentException("Units not of same type");
        }
    }
