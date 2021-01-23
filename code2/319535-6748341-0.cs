    public abstract class Tier
    {
        public abstract void DoSomething();
    }
    class TierMap : ClassMap<Tier>
    {
        public TierMap()
        {
            DiscriminateSubClassesOnColumn("TierName");
        }
    }
    public class LessThan100K : Tier
    {
        public override void DoSomething()
        {
            // Do something useful
        }
    }
    class LessThan100KMap : SubclassMap<LessThan100K>
    {
        public LessThan100KMap()
        {
            DiscriminatorValue("<$100K");
        }
    }
