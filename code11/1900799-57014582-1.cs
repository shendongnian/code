    public abstract class VehicleSchema_AFV : VehicleSchema
    {
    //Sub AFV Classes
    //========================================================================================================================//
    public abstract class Hovercraft : VehicleSchema_AFV
    {
        public override void UpdateWorldState()
        {
            VehicleCtrler.UpdatePosition(transform.forward, false);
            VehicleCtrler.UpdateYawRotation(false);
            VehicleCtrler.AlignToTerrain(false, false);
            VehicleCtrler.UpdateTurretRotation(TurretObj);
        }
    }
    public abstract class Trackedcraft : VehicleSchema_AFV
    {
        public override void UpdateWorldState()
        {
            VehicleCtrler.UpdatePosition(transform.forward, false);
            VehicleCtrler.UpdateYawRotation(false);
            VehicleCtrler.AlignToTerrain(true, false);
            VehicleCtrler.UpdateTurretRotation(TurretObj);
        }
    }
    public abstract class Wheeledcraft : VehicleSchema_AFV
    {
        public override void UpdateWorldState()
        {
            VehicleCtrler.UpdatePosition(transform.forward, false);
            VehicleCtrler.UpdateYawRotation(true);
            VehicleCtrler.AlignToTerrain(true, true);
            VehicleCtrler.UpdateTurretRotation(TurretObj);
        }
    }
