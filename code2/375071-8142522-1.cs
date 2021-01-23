    public abstract class Stats
    {
        // put your fields here
        public bool Exists { get; set; }
        public int Count { get; set; }
        public Frob Foo { get; set; }
        public abstract void Fill();
    }
    public class UniquesProcedureStats : Stats
    {
        public override void Fill()
        {
            // make call to call Uniques
            this.Exists = false;
            this.Count = 1
        }
    }
    public class HitsProcedureStats : Stats
    {
        public override void Fill()
        {
            // make call to call HitsProcedure
            this.Exists = true;
            this.Foo = new Frob();
        }
    }
