    class paramID
    {
        // rest of things
  
        public override bool Equals(object obj)
        {
             paramID p = (paramID)obj;
             // how do you determine if two paramIDs are the same?
             if(p.key == this.key) return true;
             return false;
        }
        public override int GetHashCode()
        {
             return this.key.GetHashCode();
        }
    }
