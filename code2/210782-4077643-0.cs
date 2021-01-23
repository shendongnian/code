    interface IPlane
    {
    void CheckLanding();
    void LandingGear();
    void Turn();
    }
    interface IVehicle
    {
    void Gas();
    void Brake();
    void Turn();
    }
    interface ITaxi
    {
    void StartMeter();
    void StopMeter();
    )
    public class Taxi: IVehicle, ITaxi
    {
    void ITaxi.StartMeter()
    void IVehicle.Gas
    void IVehicle.Brake
    void ITaxi.StopMeter()
    {
    public class AirPlane: IVehicle, IPlane
    {
    void IVehicle.Gas()
    void IVehicle.Turn()
    void IPlane.LandingGear()
    void IPlane.Turn()
    void IPlane.CheckLanding()
    void IPlane.Turn()
    void IPlane.LandingGear()
    void IVehicle.Brake()
    void IVehicle.Turn()
    }
