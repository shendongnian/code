    public class PartyGroupComparer:IEqualityComparer<PartyGroup>
    {
        public bool Equals(PartyGroup g1, PartyGroup g2)
        {
            return g1.PartyGroupId.Equals(g2.PartyGroupId);
        }
    
        public int GetHashCode(PartyGroup g)
        {
            return g.PartyGroupId;
        }
    }
