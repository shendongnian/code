    [HttpGet("{id:int}")]
    public IActionResult GetVehicle(int id) {
        try{
            var specificVehicle = _vehicleRepository.GetVehicleById(id);
    
            if (specificVehicle == null) return NotFound();
            return Ok(_mapper.Map<VehicleViewModel>(specificVehicle));
        }
        catch(Exception ex)
        {
            _logger.LogError($"Failed to retrieve specific vehicle : {ex}");
            return BadRequest("An Error Ocurred retrieving a specific vehicle. 
             Check Logs.");
         }
    }
