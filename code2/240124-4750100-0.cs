	class Airplane
	{
		private string name{get; set;}
		private Position PlanePosition;
		private static int numberCreated;
		public double speed
		{
			get { PlanePosition.Speed = value; }
			set { return PlanePosition.speed; }
		}
		
		public Airplane()
		{
			this.PlanePosition = new Position();
		}
		public void Accelerate()
		{
			// increase the speed of the airplane    
			if (PlanePosition.speed < Position.MAX_SPEED)
			{
				PlanePosition.speed +=1;  // or speed += 1;
			}//end of if
			numberCreated++;  // increment the numberCreated each time an Airplane object is created    
		}
	}
