    public interface ICar
    {
        SteeringWheel SteeringWheel { get; }
        Pedal Accelerator { get; }
        Pedal Brake { get; }
    }
    public class BMW : ICar { /* same as before */ }
    public class Audi : ICar { /* same as before */ }
    public class Driver
    {
        public void ParticipateInRace(ICar anyCar)
        {
            anyCar.Accelerator.Press();
            anyCar.SteeringWheel.TurnLeft();
            anyCar.SteeringWheel.TurnRight();
            anyCar.Accelerator.Release();
            anyCar.Brake.Press();
            anyCar.Brake.Release();
        }
    }
