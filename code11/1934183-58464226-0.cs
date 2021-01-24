        public float RotationCar = 1;
		public State StateCar = State.Increasing;
        if (StateCar == State.Increasing )
        {
            if (RotationCar < 30) 
            {
                RotationCar += Time.deltaTime * 2;
            }
            else 
            {
                 StateCar = State.Decreasing;
            }
        }
        if (StateCar == State.Decreasing) 
        {
            if (RotationCar > -30)
            {
                RotationCar -= Time.deltaTime * 2;
		    }
            else 
            {
                 StateCar = State.Increasing;
            }
         }
        
