    public interface Car
    {
        SteeringWheel SteeringWheel { get; }
        Pedal Accelerator { get; }
        Pedal Brake { get; }
    }
    public class BMW : Car { /* same as before */ }
    public class Audi : Car { /* same as before */ }
    public class Driver
    {
        public void ParticipateInRace(Car anyCar)
        {
            anyCar.Accelerator.Press();
            anyCar.SteeringWheel.TurnLeft();
            anyCar.SteeringWheel.TurnRight();
            anyCar.Accelerator.Release();
            anyCar.Brake.Press();
            anyCar.Brake.Release();
        }
    }
