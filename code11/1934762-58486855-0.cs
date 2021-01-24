    [ProducesResponseType(typeof(Floor), 200)] // <-- THIS
    [HttpGet("Floors/{floorId}", Name = "FloorById")]
    public IActionResult GetFloor(int floorId) {
        try {
            Floor floor = _repository.Floor.GetFloor(floorId);
            if (floor == null)
                return NotFound();
            return Ok(floor);
        } catch (Exception e) {
            return StatusCode(500, "text");
        }
    }
