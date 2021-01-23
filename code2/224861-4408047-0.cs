    public abstract class I2PinsWallPlug
    {
        protected const int Pinsdistance = 1;
        protected const int PinsLength = 5;
        public abstract void Plug();
        public abstract void Unplug();
    }
    public class MyAppliance : I2PinsWallPlug
    {
        public override void Plug()
        {
            
        }
        public override void Unplug()
        {
            
        }
    }
