    interface IVehicle
    {
        void MoveForward();
    }
    class Car : IVehicle
    {
        public void MoveForward()
        {
            ApplyGasPedal();
        }
        private void ApplyGasPedal()
        {
            // some stuff
        }
    }
    class Bike : IVehicle
    {
        public void MoveForward()
        {
            CrankPedals();
        }
        private void CrankPedals()
        {
            // some stuff
        }
    }
