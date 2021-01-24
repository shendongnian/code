    public class BMW 
    {
        public SteeringWheel SteeringWheel { get; set; }
        public Pedal Accelerator { get; set; }
        public Pedal Brake { get; set; }
    }
    public class BMWDriver
    {
        public void ParticipateInRace(BMW myBMW) 
        {
            myBMW.Accelerator.Press();
            myBMW.SteeringWheel.TurnLeft();
            myBMW.SteeringWheel.TurnRight();
            myBMW.Accelerator.Release();
            myBMW.Brake.Press();
            myBMW.Brake.Release();
        }
    }
