    public class Contract
    {
        public virtual Driver Driver { get; protected set; }
        public virtual RacingVehicle RacingVehicle { get; protected set; }
        public int SeasonsRemaining { get; protected set; }
    }
