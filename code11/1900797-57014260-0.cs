    class Hovercraft : IUpdatableVehicle
    {
    	public void Update()
    	{
    		UpdatePosition(transform.forward, false);
    		UpdateYawRotation(false);
    		AlignToTerrain(false, false);
    
    		VehicleSchema_AFV afv = (VehicleSchema_AFV)VehicleSchema;
    		UpdateTurretRotation(afv.TurretObj);
    	}
    }
    
    class Wheeledcraft : IUpdatableVehicle
    {
    	public void Update()
    	{
    		UpdatePosition(transform.forward, false);
    		UpdateYawRotation(true);
    		AlignToTerrain(true, true);
    
    		VehicleSchema_AFV afv = (VehicleSchema_AFV)VehicleSchema;
    		UpdateTurretRotation(afv.TurretObj);
    	}
    }
    // And so on ...
