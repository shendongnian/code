    public class Audi 
    {
        public SteeringWheel SteeringWheel { get; set; }
        public Pedal Accelerator { get; set; }
        public Pedal Brake { get; set; }
    }
    public class AudiDriver
    {
        public void ParticipateInRace(Audi myAudi) 
        {
            myAudi.Accelerator.Press();
            myAudi.SteeringWheel.TurnLeft();
            myAudi.SteeringWheel.TurnRight();
            myAudi.Accelerator.Release();
            myAudi.Brake.Press();
            myAudi.Brake.Release();
        }
    }
