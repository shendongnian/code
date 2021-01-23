    public class Pair : IEquatable<Pair>
    {
        public double Rank;
        public double Scenario;
    
        public bool Equals(Pair p)
        {
            return Rank == p.Rank && Scenario == p.Scenario;
        }
    
        public override int GetHashCode()
        {
            int hashRank= Rank.GetHashCode();
            int hashScenario = Scenario.GetHashCode();
            return hashRank ^ hashScenario;
        }
    }
