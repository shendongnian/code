    abstract class Vehicle
    {
        protected abstract int BaseFee { get; }
        protected abstract int ExtraFee { get; }
        public int CalculateFee()
        {
            return BaseFee + ExtraFee;
        }
    }
    abstract class CommercialVehicle : Vehicle
    {
        protected override int BaseFee
        {
            return 100;
        }
    }
    
    class LightDutyTruck : CommercialVehicle
    {
        protected override int ExtraFee
        {
            return 50;
        }
    }
    class Semi : CommercialVehicle
    {
        protected override int ExtraFee
        {
            return 150;
        }
    }
    [etc...]
    abstract class PrivateVehicle : Vehicle
    {
        protected override int BaseFee
        {
            return 25;
        }
    }
    class Sedan : PrivateVehicle
    {
        protected override int ExtraFee
        {
            return 15;
        }
    }
